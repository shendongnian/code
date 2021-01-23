    public class TimeZoneConverter : System.Windows.Data.IValueConverter
    {
        public static IList<City> Cities = new List<City>
        {
            new City() { Name= "chicago", Zone = City.eZones.Central },
            new City() { Name= "denver", Zone = City.eZones.Mountain },
            new City() { Name= "calgary", Zone = City.eZones.Mountain }
        };
           
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "???";
    
            if ((value != null) && (!string.IsNullOrWhiteSpace(value.ToString() )))
            {
                var city = Cities.FirstOrDefault(town => town.Name == value.ToString().ToLower());
    
                if (city != null)
                    result = city.Zone.ToString();
    
            }
    
            return result;
    
        }
    
        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
