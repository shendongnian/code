    public class PersonMap : ClassMap<PersonEntity>
    {
        public PersonMap()
        {
            Schema("dbo");
            Table("People");
    
            Id(x => x.Id).GeneratedBy.Identity();
            Property(x => x.FirstName).Not.Nullable();
            Property(x => x.LastName).Not.Nullable();
            Property(x => x.Email).Not.Nullable();
            Property(x => x.Phone).Not.Nullable();
            Property(x => x.MobilePhone);
        }
