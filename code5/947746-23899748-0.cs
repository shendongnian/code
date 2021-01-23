    public class Base
    {
        public int Id { get; set; }
    }
    
    public class Bar : Base {  }
    
    public class Foo : Base
    {
        private int? _parentId;
        
        public int? ParentId { 
            get{ return _parentId; } 
            set{ 
                _parentId = value;
                if( OnParentChangeAction != null ) {
                    OnParentChangeAction( _parentId ); 
                }
            } 
        }
        public Base Parent { get; set; }
    
        public int? FooParentId { get; set; }
        public Foo FooParent { get; set; }
    
        public int? BarParentId { get; set; }
        public Bar BarParent { get; set; }
        
        private Action<int?> OnParentChangeAction{ get; set; }
        
        public Foo(Foo parent)
        {
            FooParent = parent;
            FooParentId = parent.Id;
    
            Parent = FooParent;
            ParentId = FooParentId;
            OnParentChangeAction = newParentId => FooParentId = newParentId;
        }
        public Foo(Bar parent)
        {
            BarParent = parent;
            BarParentId = parent.Id;
    
            Parent = BarParent; 
            ParentId = BarParentId; 
            OnParentChangeAction = newParentId => BarParentId = newParentId;
        }
    }
