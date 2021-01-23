    public class ParentClass
    {
    }
    
    public interface ICommon
    {
        int CommonVariable { get; set; }
    }
    
    public class A : ParentClass : ICommon
    {
        public int A_item1;
        public string A_item2;
        public int CommonVariable { get; set; }
    }
    
    public class B : ParentClass : ICommon
    {
        public int B_item1;
        public string B_item2;
        public int CommonVariable { get; set; }
    }  
    private List<ICommon> AssignValue(List<ICommon> lstParent)
    {
        foreach (var item in lstParent)
            item.CommonVariable = 5;
        return lstParent;
    }
