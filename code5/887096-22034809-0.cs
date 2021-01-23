    [Serializable]
    public class Test1()
    {
        public Test1()
        {
            throw new InvalidOperationException("Default constructor shouldn't be used")
        }
    
        public Test1(int i, int j)
        {
    
        }
    
        public Test1(int i, int j, int k)
        {
    
        }
     }
