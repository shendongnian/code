       [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct)]
    public class ExportName : Attribute
    {
       public ExportName(string name) { this.Name = name }
       public string Name {get;set;}
    }
