            long t = 0;
            bool test = Int64.TryParse(p, out t);
            
            if(!test)
            {
               Console.WriteLine("Wrong String format");
               return;
            }
             
            while (t > 0)
            {
                //do stuff
            }
