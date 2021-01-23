    using(var reader = new StreamReader(...))
    {
         string line;
         while((line = reader.ReadLine()) != null)
               Console.WriteLine(line);
    }
