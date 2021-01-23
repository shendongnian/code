    var notifications = (from t in db.Tbl_Tasks
                                         join tu in db.Tbl_User_Task on t.TaskId equals tu.Task_Id
                                         where u.UserID==Id && t.TaskStart == startdate && t.TaskEnd == enddate 
                                         orderby t.TaskStart
                                         select new
                                         {
                                             t.TaskId,
                                             t.Task,
                                             tu.AdminComment,
                                         }).ToList(); 
        var NotificationList = notifications.GroupBy(x => x.Task_User_Id).Select(group => group.LastOrDefault()).ToList();
        Session["MyTaskListSession"] = NotificationList;  
