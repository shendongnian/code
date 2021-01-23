    public class WrapperProcessingQueue : ProcessingBufferBlock<MyClient, MyWrapper>
    {
        public WrapperProcessingQueue(Int32 boundedCapacity, Int32 degreeOfParalellism, CancellationToken cancellation)
            : base(boundedCapacity, degreeOfParalellism, cancellation)
        { }
        protected override async Task<MyWrapper> ProcessAsync(MyClient input)
        {
            await Task.Delay(5000);
            if (input.Id % 3 == 0)
                return null;
            return new MyWrapper(input);
        }
    }
