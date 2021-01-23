    interface IExplicit
    {
        void Explicit();
    }
    class Something : IExplicit
    {
        void IExplicit.Explicit()
        {
        }
    }
