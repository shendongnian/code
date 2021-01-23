    List<string> list = new List<string>();
    list.Add("access");
    list.Add("Addition");
    list.Add("account");
    list.Add("base")
    list.Add("Brick")
    list.Add("zammer")
    list.Add("Zilon")
    list = list.Where(r => char.IsLower(r[0])).OrderBy(r => r)
          .Concat(list.Where(r => char.IsUpper(r[0])).OrderBy(r => r)).ToList();
    for (int i = 0; i < list.Count; i++)
        Console.WriteLine(list[i]);
