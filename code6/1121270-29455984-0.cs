     int result = 0;
     foreach(string item in input)
     {
         if(Int32.TryParse(item, out result))
         {
            output1.Add(result);
         }
         else
         {
            output2.Add(item);
         }
     }
