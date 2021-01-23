    public class Account
    {
        public int Balance { get; set; }
        public Account(int startingBalance)
        {
            this.Balance = startingBalance;
        }
        private bool Debit(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\n\nError. Incorrect amount.");
                return false;
            }
            if (amount > this.Balance)
            {
                Console.WriteLine("\n\nDebit amount exceeded account balance.");
                return false;
            }
            this.Balance -= amount;
            Console.WriteLine("\n\nWithdrawal was successful. Thankyou for using our services.");
            return true;
        }
        public void RequestDebit()
        {
            bool success;
            do
            {
                Console.Write("\n\nEnter the amount you want to withdraw in Rs: ");
                int withdrawalAmount = Convert.ToInt32(Console.ReadLine());
                success = this.Debit(withdrawalAmount);
            } while (!success);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int accountBalance;
            do
            {
                Console.Write("Enter your account balance: ");
                accountBalance = Convert.ToInt32(Console.ReadLine());
            } while (accountBalance <= 0);
            var myAccount = new Account(accountBalance);
            myAccount.RequestDebit();
            int inputNumber;
            do
            {
                Console.WriteLine("\n\nPress 1 to exit, 2 to withdraw again, 3 to check your account balance.\n");
                inputNumber = Convert.ToInt32(Console.ReadLine());
                switch (inputNumber)
                {
                    case 2: myAccount.RequestDebit();
                        break;
                    case 3:
                        Console.WriteLine("\n\nYour remaining account balance is: {0}", myAccount.Balance);
                        break;
                }
            } while (inputNumber != 1);
        }
    }
