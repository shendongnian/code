    public class someObj : IEquatable<someObj>
    {
        public int someobjParam {get;set;}
        public int someobjParamTwo {get;set;}
        // override GetHashCode() and Equals(); for an example
        // see http://msdn.microsoft.com/en-us/library/ms131190%28v=vs.110%29.aspx
    }
