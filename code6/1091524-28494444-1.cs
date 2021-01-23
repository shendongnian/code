    public interface IRefreshAble
    {
        void Refresh();
    }
    public interface ICanDeleteItem
    {
        void Delete(/*parameters omitted*/);
        bool CanDelete { get; }
    }
