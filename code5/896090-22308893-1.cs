    internal static class GlobalVariables
    {
        private static readonly login_log cashier = new login_log();
        private static readonly List<customer> customer = new List<customer>();
        public static login_log Cashier { get { return cashier; } }
        public static IList<customer> Customer { get { return customer; } }
    }
