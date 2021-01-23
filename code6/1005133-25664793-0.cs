    [ProtoContract]
    sealed class DbGeographyPoco
    {
        [ProtoMember(1)]
        public string Value { get; set; }
    
        public static implicit operator DbGeographyPoco(DbGeography value)
        {
            return value == null ? null : new DbGeographyPoco {
                Value = value.ToString() };
        }
        public static implicit operator DbGeography(DbGeographyPoco value)
        {
            return value == null ? null : DbGeography.FromText(value.Value);
        }
    }
