    public async Task DoWork()
    {
       while (true)
      {
          if (!fc.SecondString.Equals(AnotherPartyLibrary.firstString))
          {
             fc.SecondString = AnotherPartyLibrary.firstString;
          }
          
    	   await Task.Delay(1000);
      }	   
    }     
