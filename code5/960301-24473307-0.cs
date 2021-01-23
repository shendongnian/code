        [Category("General")]
        [DisplayName("Foos")]
        [Description("Bla Foo Bla")]
        [TypeConverter(typeof(FoosCoverter))]
        public string[] Foos { get; set; }
