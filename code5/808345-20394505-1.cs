    [Class(Table = "APVENDP")]
    public class APVendor
    {
        [CompositeId(1)]
        [KeyProperty(2, Name = "CmAddress", Column = "B5AOCD")]
        [KeyProperty(3, Name = "InternalCompanyCode", Column = "B5COCD")]
        [Column(Name = "B5COCD")]
        private int? internalCompanyCode = 0;
        
        [Column(Name = "B5AOCD")]
        private int? cmAddress = 0;
        
        [Property(Name = "ContactNumber", Column = "B5AMCD", Precision = 3, Scale = 0)]
        [Column(Name = "B5AMCD")]
        private int? contactNumber = 0;
        
        [Property(Name = "CurrencyCode", Column = "B5B3CD", Length = 4)]
        [Column(Name = "B5B3CD")]
        private String currencyCode = "";
    
        ...
    }
