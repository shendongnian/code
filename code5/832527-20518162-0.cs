       if(result == MessageBoxResult.Yes)
       {
         int userid = viewuser.AuditUserId;
         var data = (string)null;
         foreach (var item in dgAllocate.SelectedItems)
         {
           // Here u have to get cAuditTransactionsEntity by item object
           data = (item as cAuditTransactionsEntity).TransactionId.ToString();
           sp.InsertInformationToAuditTasks(userid, data, "15000", DateTime.Now);
         }
       }
