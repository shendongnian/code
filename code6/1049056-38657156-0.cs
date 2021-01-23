        public class BoxMullerNormal
            {                       
                private MathNet.Numerics.Distributions.Normal normal;
        
                public BoxMullerNormal(double mean = 0,double std = .01)
                {
                    normal = new MathNet.Numerics.Distributions.Normal(mean,std);            
                }
                
                public override dynamic getRandom()
                {
                    // Implementation Uses C#MathNet.Numerics Normal Distribution Sampling
                    return normal.Sample();                          
                }
    }
