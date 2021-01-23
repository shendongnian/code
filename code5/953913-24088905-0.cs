    public class NumberToSpecialStringConverter : DependencyObject, IValueConverter
    {
        public displayFormat CurrentFormat
        { //Dependency property stuff }
        
        //Other DP stuff, use the 'propdp' snippet to get it all, or look on MSDN
        public Convert(...)
        {
           //This is going to the UI, from the Model
           return displayFormat.Convert(value); //Or whatever you have
        }
        public ConvertBack(...)
        {
           //This is going to the Model, from the UI
           return displayFormat.ConvertBack(value); //Or whatever you have
        }
    }
