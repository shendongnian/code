    List<string> list = new List<string>();
           using (var reader = new StreamReader(Path, enc))
           { 
               list.AddRange(reader.ReadLine().Split(new char[] { '#', '#' }, StringSplitOptions.RemoveEmptyEntries).ToList());
           }
    
