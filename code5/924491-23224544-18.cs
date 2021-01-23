    [DataContract(Name = "BusinessRuleFaultExceptionType", Namespace = "http://someurl.temp")]
    [XmlType("BusinessRuleFaultExceptionType", Namespace = "http://someurl.temp")]
    [XmlRoot("BusinessRuleFaultExceptionType", Namespace = "http://someurl.temp")]
    public sealed class BusinessRuleFaultExceptionType
    {
    	//[DataMember]
    	[XmlElement(IsNullable = false, Namespace = "http://namespaces2.url")]
    	public int Code { get; set; }
    
    	[XmlElement(IsNullable = false, Namespace = "http://namespaces2.url")]
    	public string Reason { get; set; }
    }
    
    public class XmlSerializerMessageFault : MessageFault
    {
    	FaultCode code;
    	FaultReason reason;
    
    	object details;
    
    	public XmlSerializerMessageFault(FaultCode code, FaultReason reason, object details)
    	{
    		this.details = details;
    		this.code = code;
    		this.reason = reason;
    	}
    
    	public override FaultCode Code
    	{
    		get { return code; }
    	}
    
    	public override bool HasDetail
    	{
    		get { return (details != null); }
    	}
    
    	protected override void OnWriteDetailContents(System.Xml.XmlDictionaryWriter writer)
    	{
    		var ser = new XmlSerializer(details.GetType());
    		ser.Serialize(writer, details);
    		writer.Flush();
    	}
    
    	public override FaultReason Reason
    	{
    		get { return reason; }
    	}
    }
    
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
    
    		BusinessRuleFaultExceptionType f = new BusinessRuleFaultExceptionType
    		{
    			Code = -100,
    			Reason = "xxx"
    		};
    
    		// create a fault message containing our FaultContract object
    		FaultException<BusinessRuleFaultExceptionType> faultException = new FaultException<BusinessRuleFaultExceptionType>(f, error.Message);
    		MessageFault faultMessage = faultException.CreateMessageFault();
    
    		var msgFault = new XmlSerializerMessageFault(faultMessage.Code, faultMessage.Reason, f);
    
    		fault = Message.CreateMessage(version, msgFault, faultException.Action);
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
