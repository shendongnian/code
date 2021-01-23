    public static List<usp_GetPaymentsResult> GetScheduledPayment(DateTime DateRun, int Fee)
    {
       using(var context = new PaymentDataContext())
       {
           var payments = DBContext.usp_GetPayments(DateRun, Fee);
           if (payments == null)
           {
              // bad database! handle error here
           } 
           return results.ToList();
       }
    }
