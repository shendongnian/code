    abstract class ElementBase:IElement
    
    {
        public abstract string TagName { get; }
        public abstract string GetXml { get; }
        protected abstract string GetNestedXml();
    }
