    var initializer = new GoogleAuthorizationCodeFlow.Initializer();
    initializer.DataStore = new FileDataStore("Tasks.ASP.NET.Sample.Store");
    initializer.ClientSecretsStream = stream;
    initializer.Scopes = new[] { TasksService.Scope.TasksReadonly };
    flow = new GoogleAuthorizationCodeFlow(initializer);
