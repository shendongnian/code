    public class EBusinessClassExceptions
        {
            public EBusinessClassExceptions(int sampleID)
            {
                Type type = GetType();
                string name = type.Name;
    
                Console.WriteLine("Im gonna get an exception message for {0} with sample {1}", name, sampleID);
            }
        }
    
        public class EHiddenFromWebException : EBusinessClassExceptions
        {
            public EHiddenFromWebException(int sampleID) : base (sampleID)
            {
    
            }
        }
    
        public static void Main()
        {
            EHiddenFromWebException ex = new EHiddenFromWebException(123);       
    
        }
