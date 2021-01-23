    public class SomeViewModel
    {
        public SomeViewModel()
        {
            this.IsActive = false;
            this.MyClass = new List<SomeClass>();
            this.MyClass.Add(new SomeClass());
            this.MyClass.Add(new SomeClass());
            
            // Test it
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public List<SomeClass> MyClass { get; set; }
    }
