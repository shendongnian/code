    public interface IMasterActions<T> where T : class
    {
        int Save(T obj);
        int Update(T obj);
    }
    public class StudentManager:IMasterActions<Student>
    {
        public int Save(Student std)
        {
           ... .....
        }
    }
