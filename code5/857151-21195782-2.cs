     var coll = new BlockingCollection<int>();            
     
     coll.CompleteAdding();   // closed for business
     int v;
     bool result = coll.TryTake(out v, Timeout.Infinite);
     Console.WriteLine(result);
