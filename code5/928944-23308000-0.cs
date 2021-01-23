     public DataTable GetDetails()
        {
            List<Student> Students = new List<Student>(){
                new Student() { Name = "Jack", Age = 1, StudentId = 100 },
                new Student() { Name = "Smith", Age = 2, StudentId = 101 },   
                       new Student() { Name = "Smit", Age = 3, StudentId = 102 },};
            DataTable studentTable = new DataTable();// Changed
           using(var reader = ObjectReader.Create(Students)) 
              {
                studentTable.Load(reader);
              }
           return studentTable; //need it?
        }
