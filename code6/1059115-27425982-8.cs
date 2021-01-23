    public interface IOperation
    {
        string FullName { get; set; }
        eOperationType OpType { get; }
        void ProcessXml(XElement node);
    }
