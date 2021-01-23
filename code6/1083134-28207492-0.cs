    public class ParentClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ParentClass()
        {
                
        }
        //Copy constructor
        public ParentClass(ParentClass parentClass)
        {
            this.Name = parentClass.Name;
            this.Age = parentClass.Age;
        }
    }
    public class SubClass : ParentClass
    {
        public int Id { get; set; }
        public SubClass(ParentClass parentClass, int id) : base(parentClass)
        {
            this.Id = id;
        }
    }
