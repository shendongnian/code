    interface IRepository
    {
        void Add(IBaseObject obj);
        IEnumerable<IBaseObject> Values { get; }
    }
