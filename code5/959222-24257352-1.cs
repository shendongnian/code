    public class RechargeLogData
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string SubscriptionNo { get; set; }
        public string Amount { get; set; }
        public string Time { get; set; }
    }
    var data = context.RechargeLogs.Where(t => t.Time >= DateTime.Today).
           Select(t => new RechargeLogData()
           {
                Id = t.Id,
                Company = t.Compnay,
                SubscriptionNo = t.SubscriptionNo,
                Amount = t.Amount,
                Time = t.Time
           });
    var tmp =  new BindingList<RechargeLogData>(data);
