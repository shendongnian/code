    var conn = new SqlConnection(connectionString);
    
    conn.Open();
    SqlCommand cmd = new SqlCommand("create table ##Tasks(id int, isCompleted bit, userDateOne datetime, actualStart datetime, actualFinish datetime, actualEndDate datetime)", conn);
    cmd.ExecuteNonQuery();
    
    DataTable localTempTable = new DataTable("Tasks");
    localTempTable.Columns.Add("id", typeof(int));
    localTempTable.Columns.Add("isCompleted", typeof(bool));
    localTempTable.Columns.Add("userDateOne", typeof(DateTime));
    localTempTable.Columns.Add("actualStart", typeof(DateTime));
    localTempTable.Columns.Add("actualFinish", typeof(DateTime));
    localTempTable.Columns.Add("actualEndDate", typeof(DateTime));
    
    for (int i = 0; i < cells.Count; i++)
    {
        var row = localTempTable.NewRow();
        row["id"] = cells[i].scheduleTaskID;
        row["isCompleted"] = (cells[i].selected == true);
        row["userDateOne"] = !string.IsNullOrEmpty(cells[i].scheduledDate) ? cells[i].scheduledDate : (object)DBNull.Value;
        row["actualStart"] = !string.IsNullOrEmpty(cells[i].actualDate) ? cells[i].actualDate : (object)DBNull.Value;
        row["actualFinish"] = !string.IsNullOrEmpty(cells[i].finishedDate) ? cells[i].finishedDate : (object)DBNull.Value;
        row["actualEndDate"] = !string.IsNullOrEmpty(cells[i].finishedDate) ? cells[i].finishedDate : (object)DBNull.Value;
    }
    
    localTempTable.AcceptChanges();
    
    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
    {
        bulkCopy.DestinationTableName = "##Tasks";
        bulkCopy.WriteToServer(localTempTable);
    }
    
    SqlCommand cmd = new SqlCommand(@"
        declare orderedUpdate cursor 
    	for 
    	select tempTasks.* from ##tasks tempTasks
    	inner join ScheduleTasks tasks on tempTasks.id =  tasks.ScheduleTaskID
    	order by tasks.sortOrder;
    
    declare @id int, @isCompleted bit, @actualStart datetime, @actualFinish datetime, @actualEndDate datetime, @userDateOne datetime;
    
    open orderedUpdate;
    fetch next from orderedUpdate INTO @id, @isCompleted, @userDateOne, @actualStart, @actualFinish, @actualEndDate 
    while @@fetch_status = 0
    begin 
    	UPDATE ScheduleTasks_Copy  
            SET 
                ActualStart=@actualStart,
                ActualFinish=@actualFinish,
                ActualEndDate=@actualEndDate,
                UserDate1=@userDateOne,
                IsCompleted=@isCompleted
            WHERE ScheduleTaskID = @id;
    end
    close orderedUpdate
    deallocate orderedUpdate", conn);
    
    cmd.ExecuteNonQuery();
