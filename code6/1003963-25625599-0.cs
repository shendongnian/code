    public class MyReturnType
    {
        public AType a {get; set;}
        public BType b {get; set;}
        public CType c {get; set;}
    }
    
    public IList<MyReturnType> GetGroupProduct(IPrincipal user, int year)
    {
        ...
        select new MyReturnType
        {
            a=...,
            b=...,
            c=...
        }).ToList(); 
    }
