    [Table]
    class Number
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int NumberID { get; set; }
    
        [Column]
        public int _personID { get; set; }
    
        [Column]
        public int PhoneNumber { get; set; }
        private EntityRef<Person> _person;
        [Association(Storage = "_person", ThisKey = "_personID", OtherKey = "PersonID", IsForeignKey = true)]
        public Person Person
        {
            get { return this._person.Entity; }
            set { 
                this._person.Entity = value;
                if (value != null)
                {
                    this._personID = value.PersonID;
                }
            }
        }  
    }
