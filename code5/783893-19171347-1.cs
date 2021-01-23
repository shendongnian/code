	public class SharePointOnErrorEventsArgs : EventArgs
	{
		public SharePointOnErrorEventsArgs(string message, ShowExceptionLevel showExceptionLevel, Exception exception)
		{
			Message = message;
			Exception = exception;
			ShowException = showException;
		}
		/// <summary>
		/// Property to allow the storage of a more verbose and explainable error message
		/// </summary>
		public string Message { get; private set; }
		/// <summary>
		/// Object to store full exception information within
		/// </summary>
		public Exception Exception { get; private set; }
		/// <summary>
		/// Boolean value allows for verbose messages to be sent up the stack without
		/// the need for displaying a full exception object, or stack trace.
		/// </summary>
		public ShowExceptionLevel ShowException { get; private set; }
	}
