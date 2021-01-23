        public event EventHandler TypeChanged;
        private string type;
    
        public string BicycleType
        {
            get { return this.type; }
            set
            {
                this.type = value;
                if (this.TypeChanged != null)
                    this.TypeChanged(this, new EventArgs());
            }
        }
        public Bicycle()
        {
        }
        private class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("heila!");
                Bicycle istanza = new Bicycle();
                istanza.TypeChanged += istanza_TypeChanged;
                istanza.BicycleType = "io";
                Console.WriteLine("io");
            }
            private static void istanza_TypeChanged(object sender, EventArgs e)
            {
                Console.WriteLine("rofkd");
            }
        }
    }
