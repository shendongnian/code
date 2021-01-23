    public class DataRowValidation : ValidationRule
    {
        public List<PersonInfo> People {get; set;}
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is BindingGroup)
            {
                BindingGroup group = (BindingGroup)value;
                People = PersonClass.personList;
                //Code to loop through list and test for duplicates
            }
         }
    }
