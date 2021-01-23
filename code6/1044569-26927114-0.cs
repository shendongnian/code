Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source)
        {
            return System.Convert.ToDateTime(source);
        }
    }
