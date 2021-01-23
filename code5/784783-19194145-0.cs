    public class BankAccount {
        public BankAccount(TextBox withBox) { // Pass it in
            iBa = 300.00m;
            num1 = Convert.ToDecimal(withBox.Text);
            balance = iBa - num1;
        }
        // ...the rest of the class
    }
