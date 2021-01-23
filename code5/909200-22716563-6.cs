    private class ContainerResolvedClass<T>
    {
        public readonly IEnumerable<IHandler<T>> Handlers;
        public ContainerResolvedClass(IEnumerable<IHandler<T>> handlers)
        {
            this.Handlers = handlers;
        }
    }
