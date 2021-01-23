    List<int> test = new List<int>();
    using (var reader = new StreamReader(@"D:\Temp\AccessEmail.txt")){
         string line;
         while ((line = reader.ReadLine()) != null){   
            //split the line
            string[] a = line.Split(' ', '\'');
            int? i = null;
            //find a valid integer
            foreach (string s in a) {
                int value;
                if (int.TryParse(s, out value))
                   i = value;
            }
            
            //add it to the list
            if(i.HasValue)
               test.Add(i.Value);    
         }
    }
    //print the number of elements in the list
    Console.WriteLine(test.Count); 
