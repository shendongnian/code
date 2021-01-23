    List<string> list = new List<string>();
    using (StreamReader reader = new StreamReader("Documents/inputName.txt"))
    {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
               var parts = line.Split(',');
               Array.Reverse(parts);
               list.Add(string.Join(" ", parts));
          }
    }
    list.Sort(new NameComparer());
    using (StreamWriter writer = new StreamWriter("outputfile.txt"))
    {
        foreach(var line in list)
             writer.WriteLine(line);
    }
