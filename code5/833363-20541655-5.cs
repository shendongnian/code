    public class StudentBLL
    {
       public static List<Student> GetAll()
       {
         using (StudentDAL studentDAL = new StudentDAL())
         {
             return studentDAL.GetAll();
         }
       }
    
       public static Student GetById(long studentId)
       {
          using (StudentDAL studentDAL = new StudentDAL())
         {
            return studentDAL.GetById(studentId);
         }
       }
    }
