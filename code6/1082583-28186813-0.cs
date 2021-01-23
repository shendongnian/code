    public interface IHasCommonProperty
    {
        int CommonProperty {get; set;}
    }
    
    public class A : ParentClass, IHasCommonProperty
    {
        public int A_item1;
        public string A_item2;
        public int CommonProperty {get ; set; }
    }
    
    public class B : ParentClass, IHasCommonProperty
    {
        public int B_item1;
        public string B_item2;
        public int CommonProperty {get ; set; }
    }  
    private List<ParentClass> AssignValue(List<ParentClass> lstParent)
    {
        foreach (var item in lstParent)
        {
            var commonInterface = item as IHasCommonProperty;
            if (commonInterface != null)
                commonInterface.CommonProperty = 5;
        }
        return lstParent;
    }
