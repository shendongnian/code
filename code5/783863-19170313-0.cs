    var studentToMove = students.FirstOrDefault(x => x.FeesTotal == students.Max(s => s.FeesTotal));
    students.Remove(studentToMove);
    students.Insert(0, studentToMove);
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
                {
                    new Student()
                        {
                            FirstName = "Joe", LastName = "Smith",
                            Fees = new Fee[]
                                {
                                   new Fee()
                                       {
                                           Amount = 55
                                       }, 
                                    new Fee()
                                        {
                                            Amount = 100
                                        }
                                }
                        },
                        new Student()
                        {
                            FirstName = "Jane", LastName = "Smith",
                            Fees = new Fee[]
                                {
                                   new Fee()
                                       {
                                           Amount = 400
                                       }, 
                                    new Fee()
                                        {
                                            Amount = 32
                                        }
                                }
                        },
                        new Student()
                        {
                            FirstName = "Sam", LastName = "Smith",
                            Fees = new Fee[]
                                {
                                   new Fee()
                                       {
                                           Amount = 3
                                       }, 
                                    new Fee()
                                        {
                                            Amount = 10
                                        }
                                }
                        }
                };
            var studentToMove = students.FirstOrDefault(x => x.FeesTotal == students.Max(s => s.FeesTotal));
            students.Remove(studentToMove);
            students.Insert(0, studentToMove);
            foreach (var student in students)
            {
                Console.WriteLine("Student: " + student.FirstName + " " + student.LastName);
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Fee[] Fees { get; set; }
        public decimal FeesTotal
        {
            get
            {
                if (Fees == null || Fees.Length == 0)
                    return 0;
                return Fees.Sum(x => x.Amount);
            }
        }
    }
    class Fee
    {
        public decimal Amount { get; set; }
    }
