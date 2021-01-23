    public sealed class DateEndAttribute : ValidationAttribute
    {
        public string DateStart { get; set; }
        public override bool IsValid(object value)
        {
            // Get value of datestart property
            string dateStartString = HttpContext.Current.Request[DateStart];
            DateTime dateEnd = (DateTime)value;
            DateTime dateStart = DateTime.Parse(dateStartString);
            // Start must be before end
            return dateStart <= dateEnd;
        }
        public override string FormatErrorMessage(string name)
        {
            return name + " has to be after startdate";
        }
    }
