    public abstract class CanNeverChange
    {
        public CanNeverChange()
        {
            //ACK!  connect to a DB!!  Oh No!!
        }
    
        protected abstract void ThisVaries();
    
        //other stuff
    }
    
    public class WantToTestThis : CanNeverChange
    {
        protected override void ThisVaries()
        {
             //do something you want to test
        }
    }
