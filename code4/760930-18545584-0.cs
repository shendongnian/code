    public class lcclsAccDueList
    {
        public lcclsAccDueList() {}
        public lcclsAccDueList(tableItem source)
        {
            LedgerName = source.LedgerName;
            LedgerId = source.LedgerId;
            // (...)
        }
    
        public string LedgerName { get; set; }
        public decimal LedgerId { get; set; }
        // (...)
    }
