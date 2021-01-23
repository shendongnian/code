    public void Read(string filename, List<Person> person)
    {
       using (StreamReader sr = new StreamReader(filename))
       {
           sr.ReadLine();
           sr.ReadLine();
           while (!sr.EndOfStream)
           {
               String FirstName = sr.ReadLine() ?? "-not defined-";
               String LastName = sr.ReadLine() ?? "-not defined-";
    
               person.Add(new Person(FirstName, LastName));
           }
       }
    }
