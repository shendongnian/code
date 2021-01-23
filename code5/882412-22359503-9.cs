    namespace System.Web.Http.ExceptionHandling
    {
    	/// <summary>Represents an unhandled exception handler.</summary>
    	public abstract class ExceptionHandler : IExceptionHandler
    	{
    		/// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.</returns>
    		Task IExceptionHandler.HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
    		{
    			if (context == null)
    			{
    				throw new ArgumentNullException("context");
    			}
    			ExceptionContext arg_14_0 = context.ExceptionContext;
    			if (!this.ShouldHandle(context))
    			{
    				return TaskHelpers.Completed();
    			}
    			return this.HandleAsync(context, cancellationToken);
    		}
    		/// <summary>When overridden in a derived class, handles the exception asynchronously.</summary>
    		/// <returns>A task representing the asynchronous exception handling operation.</returns>
    		/// <param name="context">The exception handler context.</param>
    		/// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    		public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
    		{
    			this.Handle(context);
    			return TaskHelpers.Completed();
    		}
    		/// <summary>When overridden in a derived class, handles the exception synchronously.</summary>
    		/// <param name="context">The exception handler context.</param>
    		public virtual void Handle(ExceptionHandlerContext context)
    		{
    		}
    		/// <summary>Determines whether the exception should be handled.</summary>
    		/// <returns>true if the exception should be handled; otherwise, false.</returns>
    		/// <param name="context">The exception handler context.</param>
    		public virtual bool ShouldHandle(ExceptionHandlerContext context)
    		{
    			if (context == null)
    			{
    				throw new ArgumentNullException("context");
    			}
    			ExceptionContext exceptionContext = context.ExceptionContext;
    			ExceptionContextCatchBlock catchBlock = exceptionContext.CatchBlock;
    			return catchBlock.IsTopLevel;
    		}
    	}
    }
