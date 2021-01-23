     var log = new Log { 
       Id = User.Identity.GetUserId().ToString(), 
       DateTimeLogged = System.DateTime.Now, 
       LogID = db.Logs.Max(item => item.LogID) }; 
     serviceRequest.Log = log;
