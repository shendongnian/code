     public Dictionary<string, string> Location_Options
        {
            get
            {
                var json = this.LocationsJson.ToString();
                if (json == string.Empty)
                {
                    return new Dictionary<string, string>();
                }
                else
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }
            }
        }
        [JsonProperty(PropertyName = "Locations")]
        public object LocationsJson { get; set; }
