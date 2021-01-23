    public class DateFormatValidation : ValidationAttribute{
        protected override bool IsValid(String myDate){
            DateTime date;
            var format = "0:dd/MM/yyyy HH:mm"
            bool parsed = DateTime.TryParseExact(myDate, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
            if(!parsed)
                return false;
            return true;
        } 
    }
