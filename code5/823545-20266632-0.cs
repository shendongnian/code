    // Base class
    [XmlInclude(typeof(XmlDerivedClass))] // Mandatory, prevents serialization errors
    [XmlType(Namespace="")]
    public abstract class XmlBaseClass
    
    // Derived class
    [XmlType("element", Namespace="")]
    public class XmlDerivedClass : XmlBaseClass
