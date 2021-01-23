    public class RateModel : ICloneable
    {
        
        ...
        
        public object Clone()
        {
            // Create a new RateModel object here, copying across all the fields from this
            // instance. You must deep-copy (i.e. also clone) any arrays or other complex
            // objects that RateModel contains
        }
    }
