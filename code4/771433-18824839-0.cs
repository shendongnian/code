     List<string> foo = new List<string>();
     foo.Add("1");
     foo.Add("2");
     foo.Add("3");
     foo.Add("4");
     Console.Write(foo.Sum(x => Convert.ToInt32(x)));
