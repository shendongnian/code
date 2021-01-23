    public class CountryCity {
      [TypeConverter(typeof(CountryConverter))]
      public string Country { get; set; }
      [TypeConverter(typeof(CityConverter))]
      public string City { get; set; }
      private static List<CountryCity> cityList = new List<CountryCity>();
      static CountryCity() {
        cityList.Add(new CountryCity() { Country = "Germany", City = "Berlin" });
        cityList.Add(new CountryCity() { Country = "Germany", City = "Hamburg" });
        cityList.Add(new CountryCity() { Country = "Germany", City = "Munich" });
        cityList.Add(new CountryCity() { Country = "US", City = "Atlanta" });
        cityList.Add(new CountryCity() { Country = "US", City = "Chicago" });
        cityList.Add(new CountryCity() { Country = "US", City = "Los Angeles" });
        cityList.Add(new CountryCity() { Country = "US", City = "New York" });
      }
      public class CityConverter : TypeConverter {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
          return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
          List<string> cities = new List<string>();
          CountryCity cc = context.Instance as CountryCity;
          if (cc != null) {
            if (cc.Country == null) {
              cities.AddRange(cityList.Select(x => x.City));
            } else {
              cities.AddRange(cityList.Where(x => x.Country == cc.Country)
                                      .Select(y => y.City));
            }
          }
          return new StandardValuesCollection(cities);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
          if (sourceType == typeof(string)) {
            return true;
          }
          return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
          if (value is string) {
            foreach (CountryCity cc in cityList) {
              if (cc.City == (string)value) {
                return cc.City;
              }
            }
          }
          return base.ConvertFrom(context, culture, value);
        }
      }
      public class CountryConverter : TypeConverter {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
          return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
          List<string> items = cityList.Select(x => x.Country).Distinct().ToList();
          return new StandardValuesCollection(items);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
          if (sourceType == typeof(string)) {
            return true;
          }
          return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
          if (value is string) {
            foreach (CountryCity cc in cityList) {
              if (cc.Country == (string)value) {
                return cc.Country;
              }
            }
          }
          return base.ConvertFrom(context, culture, value);
        }
      }
    }
