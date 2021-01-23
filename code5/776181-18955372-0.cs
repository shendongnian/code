    //var l = new List<string>(); // you don't need this
    var l = line.Split(null).ToList();
    var lastItem = l.Last(); // line.Split(null).Last(); don't split twice
    var newItem = Convert.ToDouble(lastItem, CultureInfo.InvariantCulture);
    /*Do some math*/
    /*Replace lastItem with newItem*/
    l[l.Count - 1] = newItem.ToString(); // change the last element
    //Console.WriteLine(line); // line is the original string don't work
    Console.WriteLine(string.Join(" ", l)); // create new string
