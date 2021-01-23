    sealed class DescriptionAttribute : Attribute
    {
        readonly string description;
        public DescriptionAttribute(string description)
        {
            this.description = description;
        }
        public string Description
        {
            get { return description; }
        }
    }
    enum Vehicle
    {
        [Description("Benz")]
        Car,
        [Description("Volvo")]
        Bus,
        [Description("Honda")]
        Bike
    }
