    public class B : IB
    {  
        public List<IA> ASet {get; set; }
        public void MethodB1()
        {
                ...
                this.SetA = new List<IA>();
                ...
        }
    }
