    var conn = new SqlConnection(connectionString);
    foreach (DataRow dr in dt.Rows)
    {
        cmd = new SqlCommand(
            @"UPDATE ScheduleTasks_Copy  
            SET 
            ActualStart=@actualStart,
            ActualFinish=@actualFinish,
            ActualEndDate=@actualEndDate,
            UserDate1=@userDateOne,
            IsCompleted=@isCompleted
            WHERE ScheduleTaskID = @scheduleTaskID
            AND SortOrder = @sortOrder");
        
        cmd.Parameters.Add("@isCompleted", System.Data.SqlDbType.Bit);
        cmd.Parameters.Add("@userDateOne", System.Data.SqlDbType.DateTime);
        cmd.Parameters.Add("@actualStart", System.Data.SqlDbType.DateTime);
        cmd.Parameters.Add("@actualFinish", System.Data.SqlDbType.DateTime);
        cmd.Parameters.Add("@actualEndDate", System.Data.SqlDbType.DateTime);
        cmd.Parameters.Add("@scheduleTaskID", System.Data.SqlDbType.Int);
        cmd.Parameters.Add("@sortOrder", dr["SortOrder"].ToString());
    }
