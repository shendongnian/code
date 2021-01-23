    public abstract class BaseEngine
    {
        public BaseEngine Instance {get; private set;}
    }
    
    public class FarrariEngine : BaseEngine
    {
        public FarrariEngine()
        {
            this.Instance = this; //This line is VERY weird to me.
        }
    }
    
    public class LawnmowerEngine : BaseEngine
    {
        public LawnmowerEngine ()
        {
            this.Instance = this;
        }
    }
    
    
    public class Program
    {
        public static Main(string[] args)
        {
            var farrari = new FarrariEngine();
            Engine currentEngine = farrari.Instance. //Works
            FarrariEngine currentFarrariEngine = (FarrariEngine)farrari.Instance. //Also works.
    
            var lawnMower = new LawnmowerEngine();
            Engine currentEngine = lawnMower.Instance. //Works
            LawnmowerEngine currentLawnmowerEngine = (LawnmowerEngine)lawnMower.Instance. //Also works.
        }
    }
