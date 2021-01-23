    <#@ template language="C#" #>
    <#@ import namespace="System.Runtime.Remoting.Messaging" #>
    public class <#= ClassName #>
    {
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }
    }
    <#+
        string ClassName
        {
            get { return (string)CallContext.LogicalGetData("ClassName"); }
        }
    #>
