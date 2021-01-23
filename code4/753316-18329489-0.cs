    public class TranslateAttribute
    {
        public string Translation { get; private set; }
        public TranslateAttribute(string translation)
        {
            Translation = translation;
        }
    }
    enum MyEnum
    {
        [Translate("abc")]
        aaaVal1,
    
        [Translate("dft")]
        aaaVal2,
        [Translate("fsdfds")]
        aaaVal3
    } 
