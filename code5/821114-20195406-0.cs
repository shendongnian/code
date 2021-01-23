    //Code outline only idea and not production quality code.
    
        var timesTried=0
        while(timesTried<5) //here I try trying to execute 5 times
        {
         using(var tran = new TransactionScope())
         {
            CallMethodA();
            CallMethodB();
            tran.Complete();
            timesTried=6
         }
          timesTried++;
        }
