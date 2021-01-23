    public class Dropdown
    {
        private string value;
        //prevent external inheritance
        private Dropdown(string value)
        {
            this.value = value;
        }
        public class Gifts : Dropdown
        {
            //prevent external inheritance
            private Gifts(string value) : base(value) { }
            public static readonly Dropdown GreetingCards =
                new Gifts("GreetingCards");
            public static readonly Dropdown VideoGreetings =
                new Gifts("VideoGreetings");
            public static readonly Dropdown UnusualGifts =
                new Gifts("UnusualGifts");
            public static readonly Dropdown ArtsAndCrafts =
                new Gifts("ArtsAndCrafts");
        }
        public class GraphicsAndDesign : Dropdown
        {
            //prevent external inheritance
            private GraphicsAndDesign(string value) : base(value) { }
            public static readonly Dropdown CartoonsAndCaricatures =
                new GraphicsAndDesign("CartoonsAndCaricatures");
            public static readonly Dropdown LogoDesign =
                new GraphicsAndDesign("LogoDesign");
            public static readonly Dropdown Illustration =
                new GraphicsAndDesign("Illustration");
        }
        public override string ToString()
        {
            return value;
        }
    }
