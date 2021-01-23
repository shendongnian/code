    interface IMasterActions<T>
    {
     int Save(T obj);
    
     int Update(T obj);
    }
    public class StudentManager:ImasterActions<Student>
    {
      public int Save(Student std)
      {
       ........
      }
    }
