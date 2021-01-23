    public struct RechargeLogData
    {
        public int Id;
        public string Company;
        public string SubscriptionNo;
        public string Amount;
        public string Time;
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
