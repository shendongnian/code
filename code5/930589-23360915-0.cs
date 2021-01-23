    using (var sr = new StreamReader(file))
    {
         while(!sr.EndOfStream)
         {
              string fileLine = sr.ReadLine();
              foreach (string piece in fileLine.Split(',')) 
              {     
                  listView1.Items.Add(piece); 
              } 
              sr.Close(); 
         }
    }
