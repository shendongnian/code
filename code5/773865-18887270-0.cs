    string line;
    List<Person> listOfPersons=new List<Person>();
    
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
        new System.IO.StreamReader(@"c:\yourFile.txt");
    while((line = file.ReadLine()) != null)
    {
        string[] words = line.Split(',');
        listOfPersons.Add(new Person(words[0],words[1],words[2]));
    }
    
    file.Close();
