    public class Parent()
    {
        public virtual DataTable FetchScore()
        {
            // blahblah
        }
    }
    
    public class ChildNormal() : Parent
    {
    }
    
    public class ChildOdd() : Parent
    {
        public override DataTable FetchScore()
        {
            DataTable dt = base.FetchScore();
            // blahblah
        }
    }
