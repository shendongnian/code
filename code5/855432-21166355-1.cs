    [Table("People")]
    public class Person : IPerson
    {
        //avoids virtual call in constructor
        private ICollection<Result> _Results;
        public Person()
        {
            _Results = new Collection<Result>();
        }
        //no annotations required. 
        //An int field named Id is a database generated key by convention
        public int Id { get; set; }
        //Person has a UserProfile (optional)
        public int? UserProfileID { get; set; }
        public UserProfile UserProfile { get; set; }
 
        //etc
        public virtual ICollection<Result> Results
        {
            get { return _Results; }
            set { _Results = value; }
        }
    }
    public class UserProfile : ModelBase
    {
        //UserProfile is always related to a Person
        public int PersonID { get; set; }
        public UserProfile Person { get; set; }
        //etc
    }
