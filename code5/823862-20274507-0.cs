    List<int> nos = new List<int>(10);
    nos.Add(1); nos.Add(2); nos.Add(3); nos.Add(4); nos.Add(5); 
    nos.Add(6); nos.Add(7); nos.Add(8); nos.Add(9); nos.Add(10);
    Random rnd = new Random();
    int n1 = rnd.Next(nos.Count);
    Console.WriteLine(nos[n1].ToString());
    nos.RemoveAt(n1);
    int n2 = rnd.Next(nos.Count - 1);
    Console.WriteLine(nos[n2].ToString());
    nos.RemoveAt(n2);
    int n3 = rnd.Next(nos.Count - 2);
    Console.WriteLine(nos[n3].ToString());
    nos.RemoveAt(n3);
    int n4 = rnd.Next(nos.Count - 3);
    Console.WriteLine(nos[n4].ToString());
    nos.RemoveAt(n4);
