    public class Bird
    {  }
    
    public class ExoticBird : Bird
    {  }
    
    public class BirdCollector<T> where T : Bird
    {
        protected Dictionary<string, T> nameToBird_;
    
        public BirdCollector(Dictionary<string, T> nameToBird)
        {
            nameToBird_ = nameToBird;
        }
    }
    
    public class ExoticBirdCollector : BirdCollector<ExoticBird>
    {
        public ExoticBirdCollector(Dictionary<string, ExoticBird> nameToBird)
            : base(nameToBird)
        { }
    
        public ExoticBird GetExoticBird(string name)
        {
            ExoticBird bird;
            if (nameToBird_.TryGetValue(name, out bird))
            {
                return bird;
            }
            else
            {
                // handle error
                return null;
            }
        }
    }
