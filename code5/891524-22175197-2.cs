    class ConfigurationMap : ClassMap<Configuration>
    {
        public ConfigurationMap()
        {
            Id(x => x.Id).Column("configurationId").GeneratedBy.Identity();
            
            // Other properties
            CheckConstraint("configurationId = 1");
        }
    }
