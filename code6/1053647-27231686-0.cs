    var t1 = Task.Factory.StartNew(() => soccerNode = /*Do something */);
    var t2 = Task.Factory.StartNew(() => basketbalNode = /*Do something */);
    var tasks = new List<Task> { t1, t2 };
                    
    Task.WaitAll(tasks.ToArray());
        
    AddToMainDocument(t1.Result);
    AddToMainDocument(t2.Result);
