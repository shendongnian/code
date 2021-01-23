    public class CustomerInformation
    {
        public Dictionary<int, string> State { get; set; }
     public int StateId {get;set;}   
     public CustomerInformation()
        {
            State = new Dictionary<int, string>()
            {
                { 0, "California"},
                { 1, "Nevada"}
            };
        }
    }
    
