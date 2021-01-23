    System.AggregateException was unhandled
      HResult=-2146233088
      Message=One or more errors occurred.
      Source=mscorlib
      StackTrace:
           at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
           at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
           at System.Threading.Tasks.Task.Wait()
           at Client.CommunicationHandler.AddMessage(String method, String args, String serverUri, String hubName) in c:\Workspace\EnvisionRealTimeRemoteOps\CodeProjectSelfHostedBroadcastServiceSignalRSample\Client\CommunicationHandler.cs:line 24
           at Client.Program.Main(String[] args) in c:\Workspace\EnvisionRealTimeRemoteOps\CodeProjectSelfHostedBroadcastServiceSignalRSample\Client\Program.cs:line 15
           at System.AppDomain._nExecuteAssembly(RuntimeAssembly assembly, String[] args)
           at System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySecurity, String[] args)
           at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
           at System.Threading.ThreadHelper.ThreadStart_Context(Object state)
           at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
           at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
           at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
           at System.Threading.ThreadHelper.ThreadStart()
      InnerException: System.Net.Http.HttpRequestException
           HResult=-2146233088
           Message=An error occurred while sending the request.
           InnerException: System.Net.WebException
                HResult=-2146233079
                Message=Unable to connect to the remote server
                Source=System
                StackTrace:
                     at System.Net.HttpWebRequest.EndGetResponse(IAsyncResult asyncResult)
                     at System.Net.Http.HttpClientHandler.GetResponseCallback(IAsyncResult ar)
                InnerException: System.Net.Sockets.SocketException
                     HResult=-2147467259
                     Message=No connection could be made because the target machine actively refused it 127.0.0.1:8083
                     Source=System
                     ErrorCode=10061
                     NativeErrorCode=10061
                     StackTrace:
                          at System.Net.Sockets.Socket.EndConnect(IAsyncResult asyncResult)
                          at System.Net.ServicePoint.ConnectSocketInternal(Boolean connectFailure, Socket s4, Socket s6, Socket& socket, IPAddress& address, ConnectSocketState state, IAsyncResult asyncResult, Exception& exception)
                     InnerException: 
