	#region
	using System;
	using System.IO;
	using System.Net;
	using System.Threading;
	#endregion
	namespace FtpUnicodeClient
	{
		public class FtpState
		{
			private readonly ManualResetEvent _wait;
			public FtpState()
			{
				OperationException = null;
				_wait = new ManualResetEvent(false);
			}
			public ManualResetEvent OperationComplete
			{
				get { return _wait; }
			}
			public FtpWebRequest Request { get; set; }
			public string FileName { get; set; }
			public Exception OperationException { get; set; }
			public string StatusDescription { get; set; }
		}
		public class AsynchronousFtpUpLoader
		{
			// Command line arguments are two strings: 
			// 1. The url that is the name of the file being uploaded to the server. 
			// 2. The name of the file on the local machine. 
			// 
			public static void Main(string[] args)
			{
				// Create a Uri instance with the specified URI string. 
				// If the URI is not correctly formed, the Uri constructor 
				// will throw an exception.
				var target = new Uri(args[0]);
				string fileName = args[1];
				var state = new FtpState();
				var request = (FtpWebRequest) WebRequest.Create(target + fileName);
				request.Method = WebRequestMethods.Ftp.UploadFile;
				// This example uses anonymous logon. 
				// The request is anonymous by default; the credential does not have to be specified.  
				// The example specifies the credential only to 
				// control how actions are logged on the server.
				request.Credentials = new NetworkCredential("demo", "demo");
				// Store the request in the object that we pass into the 
				// asynchronous operations.
				state.Request = request;
				state.FileName = fileName;
				// Get the event to wait on.
				ManualResetEvent waitObject = state.OperationComplete;
				// Asynchronously get the stream for the file contents.
				request.BeginGetRequestStream(EndGetStreamCallback, state);
				// Block the current thread until all operations are complete.
				waitObject.WaitOne();
				// The operations either completed or threw an exception. 
				if (state.OperationException != null)
				{
					throw state.OperationException;
				}
				Console.WriteLine("The operation completed - {0}", state.StatusDescription);
			}
			private static void EndGetStreamCallback(IAsyncResult ar)
			{
				var state = (FtpState) ar.AsyncState;
				// End the asynchronous call to get the request stream. 
				try
				{
					Stream requestStream = state.Request.EndGetRequestStream(ar);
					// Copy the file contents to the request stream. 
					const int bufferLength = 2048;
					var buffer = new byte[bufferLength];
					int count = 0;
					int readBytes;
					FileStream stream = File.OpenRead(state.FileName);
					do
					{
						readBytes = stream.Read(buffer, 0, bufferLength);
						requestStream.Write(buffer, 0, readBytes);
						count += readBytes;
					} while (readBytes != 0);
					Console.WriteLine("Writing {0} bytes to the stream.", count);
					// IMPORTANT: Close the request stream before sending the request.
					requestStream.Close();
					// Asynchronously get the response to the upload request.
					state.Request.BeginGetResponse(EndGetResponseCallback, state);
				}
					// Return exceptions to the main application thread. 
				catch (Exception e)
				{
					Console.WriteLine("Could not get the request stream.");
					state.OperationException = e;
					state.OperationComplete.Set();
				}
			}
			// The EndGetResponseCallback method   
			// completes a call to BeginGetResponse. 
			private static void EndGetResponseCallback(IAsyncResult ar)
			{
				var state = (FtpState) ar.AsyncState;
				try
				{
					var response = (FtpWebResponse) state.Request.EndGetResponse(ar);
					response.Close();
					state.StatusDescription = response.StatusDescription;
					// Signal the main application thread that  
					// the operation is complete.
					state.OperationComplete.Set();
				}
					// Return exceptions to the main application thread. 
				catch (Exception e)
				{
					Console.WriteLine("Error getting response.");
					state.OperationException = e;
					state.OperationComplete.Set();
				}
			}
		}
	}
