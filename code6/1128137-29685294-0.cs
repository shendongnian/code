    public class PaymentViewModel
    {
        // ID property unnecessary here because it doesn't need
        // to be posted from the form
        public string Details { get; set; }
        // You may want to use something like `List<ExpenseViewModel>`
        // based on your needs
        public List<Expense> Expenses { get; set; }
    }
