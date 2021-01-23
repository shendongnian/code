    public abstract class Processor<T>
    {
        public void Process(T obj);
        public void Process(object obj)
        {
            Process((T)obj);
        }
    }
    public class Task1Processor:Processor<Task1>
    {
         .....
    }
