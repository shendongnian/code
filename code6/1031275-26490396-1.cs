    public class Parent : IParent
    {
        public int ParentId { get; set; }
        public Child Child { get; set; }
        public int IParent.ParentId { get { return ParentId; } set { ParentId = value; } }
        public IChild IParent.Child { get { return Child; } set { Child = value; } }
    }
    
    public class Child : IChild
    {
        public int ChildId { get; set; }
        public Parent Parent { get; set; }
        public int IChild.ChildId { get { return ChildId; } set { ChildId = value } } }
        public IParent IChild.Parent { get { return Parent; } set { Parent = value } } }
    }
