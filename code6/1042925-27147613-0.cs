    public class AreYouOneOfTheFollowingConverter : ConverterBase
    {
        protected override bool CustomNullHandling
        {
            /// you need to tell the converter not 
            /// to handle empty values automatically
            get { return true; } 
        }
    
        public override object StringToField(string from)
        {
             /// etc...
        }
    }
