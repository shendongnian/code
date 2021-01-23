    public class NumberToSpecialStringConverter : IMultiValueConverter
    {
        public Convert(...)
        {
           //This is going to the UI, from the Model
           return (value[1] as DisplayFormat).Convert(value[0]); //Or whatever you have
        }
    
        public ConvertBack(...)
        {
           //This is going to the Model, from the UI
           return (value[1] as DisplayFormat).ConvertBack(value[0]); //Or whatever you have
        }
    }
