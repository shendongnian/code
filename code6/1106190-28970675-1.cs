    public class TranslatorMetaData
    {
        [DefaultValue("Unknown")]
        string Source { get; set; }
    
        [DefaultValue(Int32.MaxValue)]
        int Order { get; set; }
    }
