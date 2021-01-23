            List<Student> lstStudents = new List<Student>();
            Student objStudent = new Student();
            objStudent.CustomProperties.Add("Name", "Rajat");
            objStudent.CustomProperties.Add("RollNo", 1);
            lstStudents.Add(objStudent);
            objStudent = new Student();
            objStudent.CustomProperties.Add("Name", "Sam");
            objStudent.CustomProperties.Add("RollNo", 2);
            lstStudents.Add(objStudent);
            foreach (Student currentSt in lstStudents)
            {
                foreach (var prop in currentSt.CustomProperties)
                {
                    Console.WriteLine(prop.Key+" " + prop.Value);
                }
                
            }
