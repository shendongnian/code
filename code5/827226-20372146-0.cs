    string line = "";
    using (StreamReader sr = new StreamReader(filename))
    {
     while((line = sr.ReadLine())!=null)
     {
      Console.WriteLine(line);
     }
    }
