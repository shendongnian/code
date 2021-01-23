    public class TransactionViewModel
    {
        public TransactionViewModel(
            List<Transaction> transactions,
            SalesAgent salesAgent)
        {
            Transactions = transactions;
            SalesAgent = salesAgent;
        }
        public List<Transaction> Transactions { get; set; }
        public SalesAgent SalesAgent { get; set; }
        public decimal MonthlyTarget
        {
            get { return (decimal) SalesAgent.MonthlyTarget; }
        }
        public string SalesAgentInitials
        {
            get
            {
                return
                    string.Format(
                        "{0}.{1}.",
                        SalesAgent.FirstName.First(),
                        SalesAgent.LastName.First());
            }
        }
        
        public IEnumerable<Transaction> ApprovedTransactions
        {
            get { return Transactions.Where(t => t.Status.Status == "Approved"); }
        }
        public IEnumerable<Transaction> PendingTransactions
        {
            get { return Transactions.Where(t => t.Status.Status == "Pending"); }
        }
        
        public IEnumerable<Transaction> DeclinedTransactions
        {
            get { return Transactions.Where(t => t.Status.Status == "Declined"); }
        }
        
        public int ApprovedCount
        {
            get { ApprovedTransactions.Count(); }
        }
        public int PendingCount
        {
            get { PendingTransactions.Count(); }
        }
        public int DeclinedCount
        {
            get { DeclinedTransactions.Count(); }
        }
        public int TotalCount
        {
            get { return Transactions.Count; }
        }
        public decimal ApprovedPercent
        {
            get { return (decimal) ApprovedCount / TotalCount }
        }
        public decimal PendingPercent
        {
            get { return (decimal) PendingCount / TotalCount }
        }
        public decimal DeclinedPercent
        {
            get { return (decimal) DeclinedCount / TotalCount }
        }
        public decimal ApprovedValue
        {
            get { return ApprovedTransactions.Select(t => (decimal?)t.AmountRequested).Sum() ?? 0; }
        }
        public decimal PendingValue
        {
            get { return PendingTransactions.Select(t => (decimal?)t.AmountRequested).Sum() ?? 0; }
        }
        public decimal DeclinedValue
        {
            get { return DeclinedTransactions.Select(t => (decimal?)t.AmountRequested).Sum() ?? 0; }
        }
        public DateTime StartMonth
        {
            get { return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); }
        }
        public DateTime EndMonth
        {
            get { return StartMonth.AddMonths(1); }
        }
        public int DaysInMonth
        {
            get { return (EndMonth - StartMonth).Days; }
        }
        public int WorkingDaysLeftInMonth
        {
            get
            {
                Enumerable
                    .Range(DateTime.Today.Day, DaysInMonth)
                    .Select(d => new DateTime(DateTime.Today.Year, DateTime.Today.Month, d))
                    .Count(date =>
                        date.DayOfWeek != DayOfWeek.Saturday &&
                        date.DayOfWeek != DayOfWeek.Sunday);
            }
        }
        public decimal SpecifiedTotal
        {
            get
            {
                return
                    ApprovedTransactions
                        .Where(t => t.DateApproved >= StartMonth && t.DateApproved < EndMonth)
                        .Select(t => (decimal?) t.AmountApproved)
                        .Sum() ?? 0;
            }
        }
        public decimal RunRate
        {
            get { return Math.Round((MonthlyTarget - SpecifiedTotal) / WorkingDaysLeftInMonth, 2); }
        }
        public string RunRateFormat
        {
            get { return RunRate.ToString("N0"); }
        }
    }
