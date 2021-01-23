    var app = new Application(...)
    {
        Task = session.Load<Task>(taskId)
    };
    
    db.Web.Applications.Create(app);
    db.SaveChanges();
    
    var actual = db.Web.Applications.Find(app.UserId, app.TaskId, app.TransactionId);
