    public enum AccountType
    {
        Retailer = 1,
        Customer = 2,
        Manager = 3,
        Employee = 4
    }
    
    static class AccountTypeMethods
    {
        public static bool IsRetailer(this AccountType ac)
        {
            return ac == AccountType.Retailer;
        }
    }
