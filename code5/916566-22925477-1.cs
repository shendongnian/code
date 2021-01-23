    [JsonProperty(PropertyName = "cost")]    
    public int Cost
        {
            get
            {
                return cost;
            }
            private set { cost = value; }
        }
        
        [JsonProperty(PropertyName = "igloo_id")]
        public int Id
        {
            get
            {
                return igloo_id;
            }
            private set { igloo_id = value; }
        }
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get
            {
                return name;
            }
            private set { name = value; }
        }
