    public interface INamed
    {
        string Name { get; }
    }
    public interface IFactory
    {
        IInterface Create(INamed obj);
    }
    public class Factory : IFactory
    {
        private readonly IResolutionRoot resolutionRoot;
        public Factory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public IInterface Create(INamed obj) 
        {
            return this.resolutionRoot.Get<IInterface>(obj.Name);
        }
    }
