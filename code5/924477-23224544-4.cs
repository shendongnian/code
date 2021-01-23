    /// <summary>
    /// Helper class for exception repackaging.
    /// </summary>
    internal class MyExceptionHandler
    {
    	/// <summary>
    	/// Handles thrown exception into internal exceptions that are being sent over to client.
    	/// </summary>
    	/// <param name="error">Exception thrown.</param>
    	/// <returns>Repackaged exception.</returns>
    	internal static Exception HandleError(Exception error)
    	{
    		// could do something here.
    		return error;
    	}
    }
    
    #region Behaviour
    /// <summary>
    /// Control the fault message returned to the caller and optionally perform custom error processing such as logging.
    /// </summary>
    public sealed class MyErrorHandler : IErrorHandler
    {
    	/// <summary>
    	/// Provide a fault. The Message fault parameter can be replaced, or set to null to suppress reporting a fault.
    	/// </summary>
    	/// <param name="error">The <see cref="Exception"/> object thrown in the course of the service operation.</param>
    	/// <param name="version">The SOAP version of the message.</param>
    	/// <param name="fault">The <see cref="System.ServiceModel.Channels.Message"/> object that is returned to the client, or service, in the duplex case.</param>
    	public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    	{
    		//If it's a FaultException already, then we have nothing to do
    		if (error is FaultException)
    			return;
    
    		error = MyExceptionHandler.HandleError(error);
    
    		var serviceDebug = OperationContext.Current.EndpointDispatcher.ChannelDispatcher.IncludeExceptionDetailInFaults;
    
    		BusinessRuleFaultExceptionType f = new BusinessRuleFaultExceptionType
    		{
    			Code = -100,
    			Reason = "xxx"
    		};
    
    		FaultException<BusinessRuleFaultExceptionType> faultException = new FaultException<BusinessRuleFaultExceptionType>(f, error.Message);
    		MessageFault faultMessage = faultException.CreateMessageFault();
    		fault = Message.CreateMessage(version, faultMessage, faultException.Action);
    	}
    
    	/// <summary>
    	/// Enables error-related processing and returns a value that indicates whether the dispatcher aborts the session and the instance context in certain cases.
    	/// </summary>
    	/// <param name="error">The exception thrown during processing.</param>
    	/// <returns>true if Windows Communication Foundation (WCF) should not abort the session (if there is one) and instance context if the instance context is not Single; otherwise, false. The default is false.</returns>
    	public bool HandleError(Exception error)
    	{
    		// could use some logger like Nlog but as an example it will do.
    		Console.WriteLine("Error occured. {0}", error);
    
    		return true;
    	}
    }
    
    /// <summary>
    /// This attribute is used to install a custom error handler for a service
    /// </summary>
    public sealed class ErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
    	/// <summary>
    	/// Type of component to which this error handled should be bound
    	/// </summary>
    	private readonly Type errorHandlerType;
    
    	/// <summary>
    	/// Initializes a new instance of the ErrorBehaviorAttribute class.
    	/// </summary>
    	/// <param name="errorHandlerType">Type of component to which this error handled should be bound</param>
    	public ErrorBehaviorAttribute(Type errorHandlerType)
    	{
    		this.errorHandlerType = errorHandlerType;
    	}
    
    	/// <summary>
    	/// Type of component to which this error handled should be bound
    	/// </summary>
    	public Type ErrorHandlerType
    	{
    		get { return errorHandlerType; }
    	}
    
    	/// <summary>
    	/// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
    	/// </summary>
    	/// <param name="description">
    	/// <para>Type: <see cref="System.ServiceModel.Description.ServiceDescription"/></para>
    	/// <para>The service description.</para>
    	/// </param>
    	/// <param name="serviceHostBase">
    	/// <para>Type: <see cref="System.ServiceModel.ServiceHostBase"/></para>
    	/// <para>The service host that is currently being constructed.</para>
    	/// </param>
    	void IServiceBehavior.Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
    	{
    	}
    
    	/// <summary>
    	/// Provides the ability to pass custom data to binding elements to support the contract implementation.
    	/// </summary>
    	/// <param name="description">
    	/// <para>Type: <see cref="System.ServiceModel.Description.ServiceDescription"/></para>
    	/// <para>The service description.</para>
    	/// </param>
    	/// <param name="serviceHostBase">
    	/// <para>Type: <see cref="System.ServiceModel.ServiceHostBase"/></para>
    	/// <para>The host of the service.</para>
    	/// </param>
    	/// <param name="endpoints">
    	/// <para>Type: <see cref="System.Collections.ObjectModel.Collection&lt;ServiceEndpoint&gt;"/></para>
    	/// <para>The service endpoints.</para>
    	/// </param>
    	/// <param name="parameters">
    	/// <para>Type: <see cref="System.ServiceModel.Channels.BindingParameterCollection"/></para>
    	/// <para>Custom objects to which binding elements have access.</para>
    	/// </param>
    	void IServiceBehavior.AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
    	{
    	}
    
    	/// <summary>
    	/// Provides the ability to change run-time property values or insert custom extension objects such as error handlers, message or parameter interceptors, security extensions, and other custom extension objects.
    	/// </summary>
    	/// <param name="description">
    	/// <para>Type: <see cref="System.ServiceModel.Description.ServiceDescription"/></para>
    	/// <para>The service description.</para>
    	/// </param>
    	/// <param name="serviceHostBase">
    	/// <para>Type: <see cref="System.ServiceModel.ServiceHostBase"/></para>
    	/// <para>The host that is currently being built.</para>
    	/// </param>
    	void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
    	{
    		IErrorHandler errorHandler;
    
    		try
    		{
    			errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);
    		}
    		catch (MissingMethodException e)
    		{
    			throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must have a public empty constructor.", e);
    		}
    		catch (InvalidCastException e)
    		{
    			throw new ArgumentException("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
    		}
    
    		foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
    		{
    			ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
    			channelDispatcher.ErrorHandlers.Add(errorHandler);
    		}
    	}
    }
    
    #endregion
