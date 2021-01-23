    public enum Fruits
    {
        Orange = 1,
        Banana = 2,
        Mango = 3,
        Olive = 4
    }
    static void Main(string[] args)
    {
        Fruits[] List = new Fruits[4];
        List[0] = Fruits.Banana;
        List[1] = Fruits.Orange;
        List[2] = Fruits.Mango;
        List[3] = Fruits.Olive;
        var sortedList = List.OrderBy(x => x);
        foreach (var item in sortedList)
        {
            Console.WriteLine(item.ToString());
        }
    }
