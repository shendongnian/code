    public class MyData
    {
        public int? Mo { get; set; }
        public int? Lines { get; set; }
        public decimal Balance { get; set; }
        public int Term
        {
            get
            {
                if (Mo == null && Lines != null)
                {
                    return Lines.Value;
                }
                if (Mo != null && Lines == null)
                {
                    return Mo.Value;
                }
                return default(int);
            }
        }
    }
