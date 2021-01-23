    public class Test
    { 
       public int TaskId {get;set;}
       public string Task {get;set;}
       public string AdminComment {get;set;}
    }
    var notifications = (from t in db.Tbl_Tasks
                                         join tu in db.Tbl_User_Task on t.TaskId equals tu.Task_Id
                                         where u.UserID==Id && t.TaskStart == startdate && t.TaskEnd == enddate 
                                         orderby t.TaskStart
                                         select new Test
                                         {
                                           TaskId=  t.TaskId,
                                           Task =  t.Task,
                                           AdminComment =  tu.AdminComment,
                                         }).ToList(); 
        var NotificationList = notifications.GroupBy(x => x.Task_User_Id).Select(group => group.LastOrDefault()).ToList();
        Session["MyTaskListSession"] = NotificationList; 
