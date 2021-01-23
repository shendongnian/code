          Object lockObj = new Object();
          Private int count =0;
    
          public void Increment()
          {
               Lock(lockObj)
               {
                     count++;
                }
           }
    }
