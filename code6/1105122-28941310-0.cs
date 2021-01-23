                List<Student> StudentsList = new List<Student>()
                {
                     new Student("Finn", 0),
                                     new Student("AJ", 0),
                                     new Student("Sami", 0),
                                     new Student("John", 0),
                                     new Student("Rey", 0)
                };
                List<Test> TestList = new List<Test>()
                                 {
                                     new Test("Finn", 100),
                                     new Test("AJ", 97),
                                     new Test("Sami", 80),
                                     new Test("John", 72),
                                     new Test("Rey", 61)
                                 };
                var results = from s in StudentsList
                              join t in TestList
                                  on s.name equals t.nameOfStudent
                              orderby s.name
                              select new { Name = s.name, Score = t.scoreOfTest, };
                foreach (var v in results)
                {
                    Console.WriteLine("Student ={0} has  Score={1}",
                    v.Name, v.Score);
                }
