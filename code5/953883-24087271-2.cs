    public class Employee
    {
        public string Name {get; set;}
        public string Title {get; set;}
        public bool Employed {get; set;} //Note this is an actual bool, not a string!
    
        public Employee(string name, string title, bool employed) //Custom constructor
        {
            Name = name;
            Title = title;
            Employed = employed;
        }
        
        public void Fire()
        {
            Employed = false;
        }
    }
