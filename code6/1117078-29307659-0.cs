     var statuses = Range(0, RowIndex)
         .Where(i => "Rejected".Equals(arrStatus[i]))
         .Select(i => new {
             OperatorName = Convert.ToString(arrOperatorName[i]),
             ProcessType = Convert.ToString(arrProcessType[i]),
             RejectedReason = Convert.ToString(arrRejectedReason[i]),
         })
         .Distinct();
    
     foreach (var status in statuses)
     {
        dtRejects.Rows.Add(new object [] {
          status.OperatorName, status.ProcessType, status.RejectedReason
        });
     }
