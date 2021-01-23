            List<string> list = new List<string>();
            foreach (var line in File.ReadLines(@"C:\Data.txt"))
            {  
               if(!string.IsNullOrEmpty(line) && line.Contains("#define"))
              {
                list.Add(line.Split(new[] { ' ' }, 
                       StringSplitOptions.RemoveEmptyEntries)[1]);
              }
            }
             foreach (var line in list)
                Console.WriteLine(line);
