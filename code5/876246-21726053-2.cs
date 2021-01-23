    public class DateFormatValidation : ValidationAttribute{
        protected override bool IsValid(object value){
            DateTime date;
            var format = "0:dd/MM/yyyy HH:mm"
            bool parsed = DateTime.TryParseExact((string)value, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
            if(!parsed)
                return false;
            return true;
        } 
    }
