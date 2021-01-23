    public class CTest : ITest
    {
        public List<int> Numbers { get; set; }
    
        // satisfies the interface
        IEnumerable<int> ITest.Numbers { 
            get { return Numbers; } 
            set { Numbers = new List<int>(value); } 
        }
        
    }
