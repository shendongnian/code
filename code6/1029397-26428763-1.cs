        class Program
    {
        class Ad
        {
            public string _name { private get; set; }
        }
        public static void Main()
        {
            Ad ad = new Ad();
            ad._name = "Name";
            Console.WriteLine(ad._name);
            Console.ReadLine();
        }
    }
