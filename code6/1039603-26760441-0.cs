    public class ParentViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        protected ParentViewModel(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
    public class ChildViewModel_1 : ParentViewModel
    {
        public string Notes { set; get; }
        public ChildViewModel_1(int Id, string Name, string Notes)
            : base(Id, Name) //Calling base class constructor
        {
            this.Notes = Notes;
        }
        public static ChildViewModel_1 MakeChild_1()
        {
            return new ChildViewModel_1(0, "Some Name", "Some notes");
        }
    }
