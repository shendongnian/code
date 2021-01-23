    Runtime Version: 4.0.30319.42000
    
    Unhandled Exception: System.AggregateException: A Task's exception(s) were not observed either by Waiting on the Task or accessing its Exception property. As a result, the unobserved exception was rethrown by the finalizer thread. ---> System.Exception: Calculation in task failed
       at UnobservedTaskException.Program.<Main>b__0() in Program.cs:line 15
       at System.Threading.Tasks.Task`1.InnerInvoke()
       at System.Threading.Tasks.Task.Execute()
       --- End of inner exception stack trace ---
       at System.Threading.Tasks.TaskExceptionHolder.Finalize()
