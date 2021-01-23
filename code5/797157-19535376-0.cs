    //You have to pass a double value into the method, because there is only one method    
    //and wants a double paramater: 
    //this is what you created: 
    public double getDeposit(double amount) // <-
    {
        double transactionAmt = 0.00;
        if (amount > 0)
        {
        balance += amount;
        transactionAmt = amount;
        }
        return transactionAmt;
    }
    //This how you should call it: 
    static void DumpContents(Account account)
    {
        Console.WriteLine(" output {0}", account.getDeposit(34.90)); //<- 
    }
