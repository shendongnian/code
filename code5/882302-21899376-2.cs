    public interface IElement
    {
        string TagName { get; }
        string GetXml { get; }
    }
    
    public abstract class ElementBase : IElement
    {
        public string TagName { get; private set; }
        public string GetXml { get; private set; }
        
        protected virtual string GetNestedXml()
        {
            throw new NotImplementedException();
        }
    }
