    if (validated)
       {
          ///Full amount is built here 
          long l = long.Parse(tempVal + key.KeyChar);        
          if (l < intMaxValue)
          {                    
             intAmount = (int)l;
             tempVal += key.KeyChar;
             Console.Write(key.KeyChar);                         
          }
