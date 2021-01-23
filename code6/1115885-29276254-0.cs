    int? ID = null;
    Console.WriteLine(Convert.ToString(ID) == string.Empty);
    Console.WriteLine(Convert.ToString(null) == null);
    object box = ID;
    Console.WriteLine(Convert.ToString(box) == string.Empty);
