       public bool ParseFile()
       {
           // ....stuff
           int i = 1;
           int count = Rows.Count();
           foreach(DataRow row in Rows)
           {
                Console.WriteLine("parsing row " + i + " from " + count + " rows");
                ++i;
                // stuff
           }
       }
