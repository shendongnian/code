    public class Dropdown
    {
        //prevent external inheritance
        private Dropdown() { }
        public class Gifts : Dropdown
        {
            //prevent external inheritance
            private Gifts() { }
            public static readonly Dropdown GreetingCards = new Gifts();
            public static readonly Dropdown VideoGreetings = new Gifts();
            public static readonly Dropdown UnusualGifts = new Gifts();
            public static readonly Dropdown ArtsAndCrafts = new Gifts();
        }
        public class GraphicsAndDesign : Dropdown
        {
            //prevent external inheritance
            private GraphicsAndDesign() { }
            public static readonly Dropdown CartoonsAndCaricatures = new GraphicsAndDesign();
            public static readonly Dropdown LogoDesign = new GraphicsAndDesign();
            public static readonly Dropdown Illustration = new GraphicsAndDesign();
        }
    }
