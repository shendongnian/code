    object lockObj = new object();
     var up = new Thread(() =>
     {
         for (int i = 0; i < 100000; i++)
         {
             lock(lockObj)
             {
                 n++;
                 temp.Add(i);                   
             }
         }
     });
     var down = new Thread(() => 
     {
         for (int i = 0; i < 100000; i++)
         {
             lock(lockObj)
             {
                 n--;
                 try
                 {
                     temp.Remove(0);
                 }
                 catch 
                 {
                     Console.WriteLine("No item {0} to remove", i);
                 }
             }
         }
    });
