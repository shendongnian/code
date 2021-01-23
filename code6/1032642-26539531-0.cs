        public string Property
        {
           get { return property; }
           set { property = value.IsNotEmpty() ? value: property;}
        }
