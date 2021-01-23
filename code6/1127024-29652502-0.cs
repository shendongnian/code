    class Person
    {
        public string Surname {get; set;}
    }
    
    class Student : Person
    {    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<student> list = new List<Student>();
    
            list.Add(new Student()
                {
                    Surname = "jordan"
                //    name ... ???
                //    year .. ?
                });
        }
    }
