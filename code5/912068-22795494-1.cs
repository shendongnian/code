    List<int> intList = new List<int>();
    foreach (string s in testString.Split(' ');
    {
       int parsedInt = 0;
       
       //Avoid bad ints
       if (int.TryParse(s, out parsedInt))
          intList.Add(parsedInt);
    }
