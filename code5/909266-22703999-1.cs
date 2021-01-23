    public class Person
    {
        int _id;
        string _name;
        public Person(string name = "")
        {
            _id = 0;
            _name = name;
        } 
    }
    public class Engineer : Person
    {
        int _problems;
        public Engineer(string name = "")
          : base(name)
        {
            _problems = 0;
        }
    }
