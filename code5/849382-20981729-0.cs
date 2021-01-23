    public class PriorityBlock<T>
    {
        private readonly BufferBlock<T> highPriorityTarget;
        public ITargetBlock<T> HighPriorityTarget
        {
            get { return highPriorityTarget; }
        }
        private readonly BufferBlock<T> lowPriorityTarget;
        public ITargetBlock<T> LowPriorityTarget
        {
            get { return lowPriorityTarget; }
        }
        private readonly BufferBlock<T> source;
        public ISourceBlock<T> Source
        {
            get { return source; }
        }
        public PriorityBlock()
        {
            var options = new DataflowBlockOptions { BoundedCapacity = 1 };
            highPriorityTarget = new BufferBlock<T>(options);
            lowPriorityTarget = new BufferBlock<T>(options);
            source = new BufferBlock<T>(options);
            Task.Run(() => ForwardMessages());
        }
        private async Task ForwardMessages()
        {
            while (true)
            {
                await Task.WhenAny(
                    highPriorityTarget.OutputAvailableAsync(),
                    lowPriorityTarget.OutputAvailableAsync());
                T item;
                if (highPriorityTarget.TryReceive(out item))
                {
                    await source.SendAsync(item);
                }
                else if (lowPriorityTarget.TryReceive(out item))
                {
                    await source.SendAsync(item);
                }
                else
                {
                    // both input blocks must be completed
                    source.Complete();
                    return;
                }
            }
        }
    }
