    //base class
    public class BST
    {
        public virtual void Find();
        public virtual void Insert()
        {
            Find();
        }
    }
    // derived class
    public class splayTree:BST
    {
        public void Find()
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
