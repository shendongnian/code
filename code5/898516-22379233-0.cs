    object locker = new object();
    Parallel.ForEach (storecode => item
         {
              storedetails sd = new storedetails(item, year, week);
              lock(locker)
              {
                  ar.Add(sd);
              }
         });
