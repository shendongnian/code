    class Wallet
    {
        public double WalletCustomer = 100;
    
        public void Pay()
        {
            WalletCustomer = (WalletCustomer - Program.Paying);            
        }
      }
    }
