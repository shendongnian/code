        public class BankAccount
        {
    
         public double Balance { get; private set;}
    
         public BankAccount() {}
    
         public BankAccount(double initialDeposit)
         {
             Deposit(initialDeposit);
         }
    
         public void Deposit(double amount)
         {
             Balance += deposit;
         }
    
         public void Withdraw(double amount)
         {
            Balance -= amount;
         }
      }
