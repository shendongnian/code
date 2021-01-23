    public class Person
    {
        public string Name { get; set; }
        public virtual string WhoAmI()
        {
            return "I'm just a person and my name is " + this.Name;
        }
    }
    public class Employee : Person
    {
        public override string WhoAmI()
        {
            return "I'm an employed person and my name is " + this.Name;
        }
    }
