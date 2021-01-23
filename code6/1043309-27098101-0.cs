    @{
         var porjectName = Request["ProjectName"];
         if (!string.IsNullOrEmpty(porjectName ))
         {
             var fromDate = DateTime.Parse(string.Format("{0}-{1}-{2}", Request["FromYear"], Request["FromMonth"], 1));
             var toDate = DateTime.Parse(string.Format("{0}-{1}-{2}", Request["ToYear"], Request["ToMonth"], 1));
             Report.GenerateReport(porjectName, fromDate, toDate);
         }
     }
