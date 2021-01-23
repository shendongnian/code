    List<dynamic> bobbies = new List<dynamic>();
    bobbies.Add(new Hashtable());
    bobbies.Add(string.Empty);
    bobbies.Add(new List<string>());
    bobbies.Add(108);
    bobbies.Add(10);
    bobbies.Add(typeof(string));
    bobbies.Add(typeof(string));
    foreach (var item in bobbies)
    {
      Console.WriteLine(item);
    }
         
     Console.ReadLine();
