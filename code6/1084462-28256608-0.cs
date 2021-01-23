       public class BankAccount
       {
          private int Balance;
    
          private Mutex MyMutex = new Mutex();
    
    
          public bool BankTransferWithMutex(int amount)
          {
             bool result = false;
    
             MyMutex.WaitOne();
    
             if (Balance >= amount)
             {
                Balance -= amount;
                result = true;
             }
    
             MyMutex.ReleaseMutex();
             //My question is here..
             return result;
          }
       }
