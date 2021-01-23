    public class StudentRepository
    {
          public IEnumerable<Student>  GetStudents(University university) 
          {
               return dbContext.Set<Student>().Where(s => s.Department.University.Id == university.Id);
          }
    }
