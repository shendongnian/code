    public class RegularMap : SubclassMap<Regular>
    {
        public RegularMap()
        {
    		Table("Regular")
            References(x => x.Special,"SpecialID");
        }
    }
    
    public class SpecialMap : SubclassMap<Special>
    {
        public SpecialMap()
        {
            HasMany(x => x.Regulars).KeyColumn("SpecialID").Where("IsDeleted = 0");
        }
    }
