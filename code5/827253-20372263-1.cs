    public class ExampleComparer : IComparer<Example>
    {
        private const string Order = "XQLHPJ";
    
        public int Compare(Example a, Example b)
        {
             int indexA = Order.IndexOf(a.GridValue);
             int indexB = Order.IndexOf(b.GridValue);
             if (indexA < indexB) { return -1; }
             else if (indexB < indexA) { return 1; }
             else { return 0; }
        }
    } 
