    System.InvalidOperationException was unhandled by user code
      _HResult=-2146233079
      _message=There were not enough free threads in the ThreadPool to complete the operation.
      HResult=-2146233079
      IsTransient=false
      Message=There were not enough free threads in the ThreadPool to complete the operation.
      Source=System
      StackTrace:
           at System.Net.HttpWebRequest.BeginGetResponse(AsyncCallback callback, Object state)
           at System.Threading.Tasks.TaskFactory`1.FromAsyncImpl(Func`3 beginMethod, Func`2 endFunction, Action`1 endAction, Object state, TaskCreationOptions creationOptions)
           at System.Threading.Tasks.TaskFactory`1.FromAsync(Func`3 beginMethod, Func`2 endMethod, Object state)
           at System.Net.WebRequest.<GetResponseAsync>b__8()
           at System.Threading.Tasks.Task`1.InnerInvoke()
           at System.Threading.Tasks.Task.Execute()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
           at ConsoleApplication1.Program.<PoolFunc>d__0.MoveNext() in c:\Users\Justin\Source\Repos\Azure\ConsoleApplication1\ConsoleApplication1\Program.cs:line 39
      InnerException: 
