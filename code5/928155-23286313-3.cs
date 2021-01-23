    public class ConcreteProcessor<T> : AbstractProcessor<T>
    {
        protected override void ProcessDataInternal(T data)
        {
            // This implementation simply writes data to the console.
            Console.WriteLine(data);
        }
    }
