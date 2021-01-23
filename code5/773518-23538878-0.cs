    class MyClass : RootMyClass
    {
        [JsonIgnore] public new string Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
            }
        }
    }
