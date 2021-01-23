    public class Table : IJustWantTheseColumnsInterface
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Address Address { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Employer Employer { get; set; }
    }
    public class SameTable : IJustWantTheseColumnsInterface
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Phone Phone { get; set; }
    }
    public interface IJustWantTheseColumnsInterface
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Phone Phone { get; set; }
    }
    public class SameTableMap : ClassMap<SameTable>
    {
        Table("Table");
        Id(x => x.Id, "ID");
        Map(x => x.FirstName, "FIRST_NAME");
        Map(x => x.LastName, "LAST_NAME");
        Reference(x => x.Phone, "PHONE_ID");
    }
