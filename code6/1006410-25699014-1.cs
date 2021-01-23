    public partial class SomeDataContract
    {
       private IEnumerable<SomeDataContract> _children;
       public IEnumerable<SomeDataContract> Children
       {
           if(_children == null)
           {
               // call the WCF service, assuming such a method exists... 
               _children = GetChildren(this.Id);
           }
           return _children;
       }
    }
