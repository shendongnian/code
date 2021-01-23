    public void CreateTask(TaskEntry taskEntry)
    {
         var webUri = new Uri("http://intranet.contoso.com/");
         var userName = "username";
         var password = "password";
         var domains = "domain";
         var client = new ListsClient(webUri);
         client.Credentials = new System.Net.NetworkCredential(userName, password, domain);
         var taskProperties = new Dictionary<string, string>();
         taskProperties["Title"] = taskEntry.TaskName;
         taskProperties["DueDate"] = taskEntry.DueDate;
         taskProperties["AssignedTo"] = taskEntry.AssignedTo;
         client.CreateListItem("Tasks", taskProperties);
    }
 
 
