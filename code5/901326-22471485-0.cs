    public class LocationHierachy
        {
            [XmlElement("Location", typeof(Country))]
            public List<Country> CountryList { get; set; }
    
            [OnDeserialized()]
            internal void OnDeserializedMethod(StreamingContext context)
            {
                foreach (var country in CountryList)
                {
                    foreach (var city in country.CityList) {
                        city.CountryId = country.Id;
                    }
                }
            }
        }
