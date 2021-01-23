    public class CheckInputDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputDate = (DateTime)value;
            var compareDate = DateTime.Now.AddDays(21);
            int result = DateTime.Compare(inputDate, compareDate);
            return result >= 0;
        }
    }
