    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("heila!");
            Bicycle istanza = new Bicycle();
            istanza.TypeChanged += new EventHandler(**istanza_TypeChanged**);
            istanza.BicycleType = "io";
            Console.WriteLine("io");
        }
        static void istanza_TypeChanged(object sender, EventArgs e) 
        {
            Console.WriteLine("rofkd");
        }
    }
