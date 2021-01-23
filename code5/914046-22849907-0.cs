        namespace BusinessEntities
        {
            [DataContract(Name = "AddressType")]
            public enum AddressType
            {
                [EnumMember(Value = "Home")]
                Home,
                [EnumMember(Value = "Mailing")]
                Mailing,
                [EnumMember(Value = "Location")]
                Location,
                [EnumMember(Value = "Other")]
                Other
            }
         }
    
