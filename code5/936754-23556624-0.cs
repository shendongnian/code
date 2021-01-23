    public class StudentsController : ApiController
    {
        IEnumerable<Student.GetDetails> GetDetails()
        {
            List<studentBO> list = new List<studentBO>();
                        
            Student.GetDetails[] dt = Student.Getdeatils();
                    
            for (int i = 0; i < dt.Length; i++)
            {
    
                studentBO.name= dt[i].name;
                studentBO.studentno= dt[i].studentno;
                studentBO.address= dt[i].address;
                
                list1.Add(studentBO);
            }   
    
            return list1; 
        }
    }
