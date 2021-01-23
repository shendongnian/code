    using System.ComponentModel.DataAnnotations
    public class Foo
    {
        public Guid Id { get; private set; }
        [StringLength(50),Required]
        public string FooName { get; private set; }
        [Required]
        public int Age { get; private set; }
        // etc props
        public Foo(string fooName, int age)
        {
            if (string.IsNullOrEmpty(fooName))
                throw new ArgumentException("FooName cannot be null or empty"); // note there is also a "minimum length" data annotation to avoid doing something like this, was just using this as an example.
            this.Id = Guid.NewGuid();
            this.FooName = fooName;
            this.Age = age;
        }
    }
    public class YourController
    {
        [HttpPost]
        public ActionResult Add(Foo foo)
        {
            if (!ModelState.IsValid)
                // return - validation warnings, etc
            
            // Add information to persistence
            // return successful add?
        }
    }
