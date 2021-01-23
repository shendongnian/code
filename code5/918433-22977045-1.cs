    var x = SomethingType.Type1.GetAttributeValue<DisplayAttribute>(e => e.Name);
.......
    class ModelClass
    {
        public SomethingType Type { get; set; }
        public string TypeName
        {
            get { return Type.GetAttributeValue<DisplayAttribute>(attribute => attribute.Name); }
        }
    }
