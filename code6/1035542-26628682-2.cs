    var x =  Test();
           foreach(dynamic o in x)
           {
               int NumberOfRegisters;
     
               //You have 2 ways... either by
               NumberOfRegisters = o.NumberOfRegisters;
    
               // or reflection
               NumberOfRegisters = o.GetType().GetProperty("NumberOfRegisters").GetValue(o, null);
    
           }
