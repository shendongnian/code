    public class MyJsonDateTimeConverter : IsoDateTimeConverter
    {
        public MyJsonDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
