    namespace studentHeirarchy
    {
        class Program
        {
            static void Main(string[] args)
            {
                runStudent();   
            }
            static void runStudent()
            {
                Student one = new Student();
                Console.WriteLine(one.About());
                Console.ReadLine();
            }
        }
    }
    
    namespace studentHeirarchy
    {
        public class ColumbiaStudent : Student
        {
            public bool isInOOP;
    
            public ColumbiaStudent() : base()
            {
                isInOOP = true;
            }
    
            public override String About()
            {
                string About = "my favorite course is OOP";
                return About;
            }
    
            public void GetOOPString()
            {
                throw new System.NotImplementedException();
            }
        }
    }
    
    namespace studentHeirarchy
    {
        public class Student : Person
        {
            public int NumCourses;
            public string SchoolName;
    
            public Student() : base()
            {
                NumCourses = 1;
                SchoolName = "Columbia";
            }
    
            public override string About()
            {
                string About = string.Format("my name is{0}, I am {1} years old, I attend {2} and am taking {3} courses."),  Name, Age, SchoolName, NumCourses;
                return About;
            }
    
            public void AddCourse()
            {
                throw new System.NotImplementedException();
            }
    
            public void DropCourse()
            {
                throw new System.NotImplementedException();
            }
        }
    }
    
    namespace studentHeirarchy
    {
        public class Person
        {
            public int Age;
            public string Name;
    
            public Person()
            {
                Age = 17;
                Name = "Jeff";
            }
    
            public virtual string About()
            {
                throw new System.NotImplementedException();
            }
        }
    }
