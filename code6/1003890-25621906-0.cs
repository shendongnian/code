    public class Weight
    {
        public int Value {get;set;}
        public static Weight operator +(Weight w1, Weight w2) 
        {
            return new Weight { Value = w1.Value + w2.Value };
        }
    }
