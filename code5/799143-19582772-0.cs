        public partial class Division
    {
        public Division()
        {
            this.Id = Guid.NewGuid();
            this.Persons = new HashSet<Person>();
            this.DevisionContnets = new HashSet<DevisionContnet>();
        }
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<DevisionContnet> DevisionContnets { get; set; }
        [HiddenInput] // this will hide your data fields
        public virtual DateTime InsertDate { get; set; }
        [HiddenInput]
        public Nullable<System.DateTime> UpdateDate { get; set; }
        [HiddenInput]
        public Nullable<System.Guid> InsertUid { get; set; }
        [HiddenInput]
        public Nullable<System.Guid> UpdateUid { get; set; }
        [HiddenInput]
        public string UpdateStatment { get; set; }
  
    }
