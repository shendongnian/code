    List<int> test = new List<int>();
    List<int> error = new List<int>();
    using (var reader = new StreamReader(@"D:\Temp\AccessEmail.txt")){
         string line;
         while ((line = reader.ReadLine()) != null){   
            //split the line
            string[] parts = line.Split(new[]{"Error"}, StringSplitOptions.None);
            
            //get valid integers
            test.Add(GetInt(parts[0].Split(' ', '\'')));
            error.Add(GetInt(parts[1].Split(' ', '\'')));
         }
    }
    //print the number of elements in the lists
    Console.WriteLine(test.Count); 
    Console.WriteLine(error.Count);
---
    int GetInt(string[] a){
        int i = 0;
        foreach (string s in a)
           int.TryParse(s, out i);
        return i;
    }
