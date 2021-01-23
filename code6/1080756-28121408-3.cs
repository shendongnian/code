    class Program
        {
            static void Main(string[] args)
            {
                Student studentA = new Student(1000, "Defense Against the Dark Arts", "Harry", "Potter", 25);
                Student studentB = (Student)studentA.Clone();
            }
        }
    
        public abstract class Person : ICloneable
        {
            public string FirstName { get; set; }
            public string Surname { get; set; }
    
            private int SomePrivateVariable { get; set; }
    
            public Person()
            {
    
            }
    
            public Person(string firstName, string surname, int privateVariableDefault)
            {
                this.FirstName = firstName;
                this.Surname = surname;
                this.SomePrivateVariable = privateVariableDefault;
            }
    
            public Person(Person original)
            {
                this.FirstName = original.FirstName;
                this.Surname = original.Surname;
                this.SomePrivateVariable = original.SomePrivateVariable;
            }
    
            public abstract object Clone();
        }
    
        public sealed class Student : Person
        {
            public int StudentId { get; set; }
            public string CourseTitle { get; set; }
    
            public Student()
            {
    
            }
    
            //Constructor with all the fields, passed down to the base class
            public Student(int studentId, string courseTitle, string firstName, string surname, int baseVariableDefault)
                : base(firstName, surname, baseVariableDefault)
            {
                this.StudentId = studentId;
                this.CourseTitle = courseTitle;
            }
    
            //A clone constructor which takes an object of the same type and populates internal 
            //and base properties during construction
            public Student(Student original)
                : base(original)
            {
                this.FirstName = original.FirstName;
                this.Surname = original.Surname;
                this.StudentId = original.StudentId;
                this.CourseTitle = original.CourseTitle;
            }
    
            public override object Clone()
            {
                Student clone = new Student(this);    
                return clone;
            }
        }
