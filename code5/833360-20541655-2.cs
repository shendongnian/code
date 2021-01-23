    public class StudentBLL
    {
       public List<Student> GetAll()
       {
         using (StudentDAL studentDAL = new StudentDAL())
         {
             return studentDAL.GetAll();
         }
       }
    
       public Student GetById(long studentId)
       {
          using (StudentDAL studentDAL = new StudentDAL())
         {
            return studentDAL.GetById(studentId);
         }
       }
    }
