    //base class
    public class BST
    {
        private void _Find()
        {
            // base.Find() implementation here
        }
    
        public virtual void Find()
        {
            _Find();
        }
    
        public virtual void Insert()
        {
            _Find();
        }
    }
    
    
    // derived class
    public class splayTree:BST
    {
        public override void Find()
        {
           base.Find();
           ...
        }
        public override void Insert()
        {
           base.Insert();
           .....
        }
    }
