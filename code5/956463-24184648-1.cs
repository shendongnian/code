    public class EnumFlagConverter : IValueConverter
    {
        public Enum CurrentValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var theEnum = value as Enum;
            CurrentValue = theEnum;
            return theEnum.HasFlag(parameter as Enum);
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theEnum = parameter as Enum;
            if (CurrentValue.HasFlag(theEnum))
                CurrentValue = CurrentValue.And(theEnum.Not());
            else
                CurrentValue = CurrentValue.Or(theEnum);
            return CurrentValue;
        }
    }
 
 
    public static class Extensions
    {
        public static Enum Or(this Enum a, Enum b)
        {
            // consider adding argument validation here
            if (Enum.GetUnderlyingType(a.GetType()) != typeof(ulong))
                return (Enum)Enum.ToObject(a.GetType(), Convert.ToInt64(a) | Convert.ToInt64(b));
            else
                return (Enum)Enum.ToObject(a.GetType(), Convert.ToUInt64(a) | Convert.ToUInt64(b));
        }
 
        public static Enum And(this Enum a, Enum b)
        {
            // consider adding argument validation here
            if (Enum.GetUnderlyingType(a.GetType()) != typeof(ulong))
                return (Enum)Enum.ToObject(a.GetType(), Convert.ToInt64(a) & Convert.ToInt64(b));
            else
                return (Enum)Enum.ToObject(a.GetType(), Convert.ToUInt64(a) & Convert.ToUInt64(b));
        }
        public static Enum Not(this Enum a)
        {
            // consider adding argument validation here
            return (Enum)Enum.ToObject(a.GetType(), ~Convert.ToInt64(a));
        }
    }
