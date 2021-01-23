    public void ExtractUsingDynamic(IEnumerable list)
    {
      var dynamicList = list.Cast<dynamic>();
      var names = dynamicList.Select(d => new
                                          {
                                            Name = d.Name,
                                            Surname = d.Surname
                                          });
      foreach (var n in names)
      {
        Console.WriteLine(n.Name + " " + n.Surname);
      }
    }
