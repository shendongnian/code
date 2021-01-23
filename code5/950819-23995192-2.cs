    class yyy
    {
        public virtual void pqr()
        {
            System.Console.WriteLine("yyy pqr");
        }
    }
    class xxx : yyy
    {
        public override void pqr()
        {
            base.pqr();
    
            System.Console.WriteLine("xxx pqr");
        }
    }
    class www : xxx
    {
        public override void pqr()
        {
            base.pqr();
    
            System.Console.WriteLine("www pqr");
        }
    }
    class vvv : www
    {
        public override void pqr()
        {
            base.pqr();
    
            System.Console.WriteLine("vvv pqr");
        }
    }
