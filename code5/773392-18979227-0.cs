     var Task = (from tbl_Task tsk in dc.tbl_Task
            join tmp in dc.tbl_TaskAssignment on tsk.TaskID equals tmp.TaskID into jointable
            from tmp in jointable.DefaultIfEmpty()
            join ct in dc.tbl_User on tmp.AssignTo equals ct.UserID
            where tsk.IsDeleted == false && tsk.TaskID == IntTaskID && 
            tmp.IsDeleted == false
            select new
            {
               TaskID = tsk.TaskID,
               TaskDesc = tsk.Remarks,
               TaskTitle = tsk.TaskTitle,
               TaskEmpName = tmp.tbl_User.tbl_Contact.FirstName_EN,
               TaskEmpID = tmp.AssignTo,
              
               Priority = tsk.Priority,
               TaskCompletedPercentage = tmp.CompletedPercentage
           }).AsEnumerable().select(row=> new {
    task = row,
    profileImage = dc.get_User_Image(tmp.AssignTo).FirstOrDefault()
})
