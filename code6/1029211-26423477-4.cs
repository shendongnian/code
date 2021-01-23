     using (var sr = new StreamReader(fPath))
     {
         while (!sr.EndOfStream)
         {
             Debug.Print(sr.ReadLine());
         }
     }
