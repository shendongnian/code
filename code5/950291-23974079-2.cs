    HashSet<string> nameSet = new HashSet<string>();
    
    List<Person> persons = getPersonList(); // get the list somehow
    
    foreach (Person p in persons) {
      string name = p.Name;
      if (!string.IsNullOrEmpty(name)) {
        if (!nameSet.Contains(name)) {
          nameSet.Add(name);
        }
      }
    }
    List<string> names = nameSet.ToArray();
    foreach (string name in names) {
      Console.WriteLine(name);
    }
