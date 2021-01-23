    static void Main(string[] args)
            {
                var list1 = new List<String>() {
                "one", "two", "three", "one", "two"};
    
                var list3 = list1
                            .GroupBy(x => x)
                            .Where(x => x.Count() > 1)
                            .ToList();
      Console.WriteLine("list3[0][0]=" + list3[0].ToList()[0].ToString()); 
    //OR  Console.WriteLine("list3[0][0]=" + list3[0].First()); 
            }
