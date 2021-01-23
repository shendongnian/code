    string myString = sr.ReadToEnd();
    foreach(var part in myString.Split(Environment.NewLine.ToCharArray()))
    {
      foreach (var part2 in part.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
      {
        file.Add(Convert.ToByte(part2));
      }
    }
