    public class Person
    {
        string _name;
        public Person(string name = "")
        {
            _name = name;
        } 
    }
    public class Engineer : Person
    {
        int _numOfProblems;
        public Engineer(string name = "")
          : base(name)
        {
            _numOfProblems = 0;
        }
    }
