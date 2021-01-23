    using Microsoft.Windows.TaskScheduler;
    using System.Linq;
    using (var ts = new TaskService(@"\\RemoteServerName", "AuthUserName", "AuthDomName", "UserPassword", false))
    {
        return ts.GetRunningTasks(true).FirstOrDefault(t => t.Name == "taskName") != null;
    }
