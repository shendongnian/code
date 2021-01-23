    namespace My.Generated.Code
    {
        public partial class GeneratedClass
        {
            ...
        }
    }
    ...
    
    namespace Some.Other.Project
    {
        using My.Generated.Code;
    
        public partial class GeneratedClass
        {
            public string NewProperty { get; set; }
    
            public void NewMethod()
            {
            }
        }
    }
