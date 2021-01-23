        [Serializable]//class to hold the common properties
        public class Saver
        {
            public Saver() { }
            public Point Location { get; set; }
            public Type Type { get; set; }
            public Size Size { get; set; }
            public string Text { get; set; }
            //add properties as you like but maker sure they are serializable too
        }
