    class Okay : IYes
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) throw new ArgumentNullException("Name");
                if (value.Length < 3) throw new ArgumentOutOfRangeException("Name");
                name = string.Join("", value.Take(10));
            }
        }
    }
    private static void GenericTester()
    {
        Okay ok = new Okay {Name = "thisIsLongerThan10Characters"};
        Console.WriteLine(ok.Name);
    }
    // Output:
    // thisIsLong
