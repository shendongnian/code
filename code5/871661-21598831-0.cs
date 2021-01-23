     public bool DateInside(DateTime checkDate, 
         DateTime fromDate, DateTime? lastDate = null)
     {
         DateTime toDate = lastDate != null ? lastDate.Value : fromDate.AddDays(6d);
         return checkDate >= fromDate && checkDate <= toDate;
     }
