    public class Class2
    {
        public int X { get; set; }
        [DefaultValue(typeof(Class1), "Name2")]
        public Class1 Name2Class { get; set; }
        public Class2()
        {
            this.SetDefaults();
        }
    }
    public class Class3
    {
        public int Y { get; set; }
        [DefaultValue(typeof(Class1), "Name3")]
        public Class1 Name3Class { get; set; }
            public Class3()
            {
                this.SetDefaults();
            }
    }
