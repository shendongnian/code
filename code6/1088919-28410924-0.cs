    foreach (EmployeejobAudit empjobAudit in list)
    {
         int iEmployeeServiceId = empjobAudit.EmployeeServiceId;
    
         PushNotificationData.jobAuditRow[] jobAuditList = empjobAudit.jobAuditList;
    
         var jobCallQuery = (from job in jobAuditList
                             where ((from dc in dataset.jobCall select dc.jobId).Contains(job.jobId)) && 
                            ( job.jobChangeTypeId != (int) Common.jobChangeTypeId.Unallocate && job.jobChangeTypeId != (int) Common.jobChangeTypeId.Delete)                                   
                             select job).Distinct();
    
         if (jobCallQuery.Any()) //Useless because the following foreach will do it for you, but you can test if != null 
         {
             foreach (var item in jobCallQuery)
             {
                 System.Diagnostics.Debug.WriteLine("jobId {0}  Employee ServiceID {1} jobChange Type ID {2}", item.jobId, item.EmployeeServiceId, item.jobChangeTypeId);
             }
         }
    }
