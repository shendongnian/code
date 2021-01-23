    [XmlInclude(typeof(ChildClass))] 
    [Serializable]
    public abstract class ParentClass
    {
        public abstract string Name { get; set; }
    }
