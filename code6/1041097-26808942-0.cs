    lineCounter = 0;
    while (!reader.EndOfStream)
    {
         var line = reader.ReadLine();
         var values = line.Split(',');
    
         if(values.Length == 1)
         {
            list4[lineCounter-1] += values[0];
         }
         else
         {
              list1.Add(values[0]);
              list2.Add(values[1]);
              list3.Add(values[2]);
              list4.Add(values[3]);
              lineCounter++;
         }
    
    }
