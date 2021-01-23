    public class Locales
    {
        public Region region { get; set; }
        public Buttons buttons { get; set; }
        public Fields fields { get; set; }
        public Locales()
        {
            region = new Region();
            buttons = new Buttons();
            fields = new Fields();
        }
    }
