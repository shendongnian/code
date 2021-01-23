    //immutable Person
    public class Person
    {
        public string Name {get; private set;}
    
        public int Age {get; private set;}
        public Person(int Age, string Name)
        {
            this.Age=Age;
            this.Name=Name;
        }
    }
