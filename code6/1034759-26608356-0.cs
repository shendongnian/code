     public class Alpha
        {
            public Alpha()
            {
                betaTest = new Beta();
            }
    
            private Beta betaTest = null;
    
            public Beta BetaTest
            {
                get { return betaTest; }
                set { betaTest = value; }
            }
    
    
    
            public class Beta
            {
            }
          
        }
