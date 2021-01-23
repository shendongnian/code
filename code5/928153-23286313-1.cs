    public class ConcreteProcessor<T> : AbstractProcessor<T>
    {
        protected override void ProcessDataInternal(T data)
        {
            Console.WriteLine(data);
        }
    }
