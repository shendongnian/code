     foreach(string item in input)
     {
         int result = 0;
         if(Int32.TryParse(item, out result))
         {
            output1.Add(result);
         }
         else
         {
            output2.Add(item);
         }
     }
