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
        [HiddenInput(DisplayValue = false)] // this will hide your data fields
        public virtual DateTime InsertDate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<System.DateTime> UpdateDate { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<System.Guid> InsertUid { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<System.Guid> UpdateUid { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UpdateStatment { get; set; }
  
    }
