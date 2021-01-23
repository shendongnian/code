    // Source
    public enum myEnum
    {
        [EnumMember]
        someEnumVal = 99,
    }
    // --------------------------------------------------------------------- //
    // Service Reference code
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="myEnum")]
    public enum myEnum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        someEnumVal  = 0,
    }
