    class Wallet
    {
         public double WalletCustomer = 100;
         Program Betalen = new Program();
         public void Pay()
         {
            WalletCustomer = (WalletCustomer - Betalen.Paying);            
         }
    }
