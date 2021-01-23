    List<Person> multipleLists = new List<Person>();
    for (int i = 0; i < Name.Count; i++)
    {
        multipleLists.Add(new Person
            {
                Name = Name[i],
                Address = Address[i],
                ZipCode = ZipCode[i]
            });
    }
