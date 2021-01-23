    public abstract class Guy 
    {
         abstract public int Height { get; set; }
    }
    
    public class TallGuy : Guy 
    {
        public override int Height 
        {
            get { return 100; }
            set { } 
        }
    }
    
    public class ShortGuy : Guy 
    {
        public override int Height 
        {
            get { return 10; }
            set { }
        } 
    }
