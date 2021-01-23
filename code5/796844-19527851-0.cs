    class NameComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            var xs = (Swimmer)x;
            var ys = (Swimmer)y;
            return xs.Name.CompareTo(ys.Name);
        }
    }
    class Swimmer
    {
        public string Name { get; set; }
    }
    class Swimmers
    {
        ArrayList AllSwimmers;
        IComparer nameComparer = new NameComparer();
    
        public Swimmers()
        {
            AllSwimmers = new ArrayList();
            AllSwimmers.Add(new Swimmer { Name = "Tom" });
            AllSwimmers.Add(new Swimmer { Name = "Joe" });
            AllSwimmers.Add(new Swimmer { Name = "George" });
            AllSwimmers.Sort(nameComparer);
        }
    
    //some other methods in between
    
        public int GetOnName()
        {
            Console.WriteLine("Enter the name of the swimmer");
            string name = Console.ReadLine();
    
            int pos = AllSwimmers.BinarySearch(new Swimmer { Name = name }, nameComparer);
    
            Console.WriteLine(pos);
    
            return pos;
    
        }
    }
