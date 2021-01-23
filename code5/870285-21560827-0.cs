    public Task<MyUser> FindByNameAsync(string userName)
    {
       var myusers = new List<MyUser> 
       { 
           new MyUser() { Id="1", UserName = "tom", Password = "secret" },
           new MyUser() { Id="2", UserName = "mary", Password = "supersecret" }
       };
    
       var task = Task.FromResult(myusers.SingleOrDefault(u => u.UserName == userName));
    
       return task;
    }
