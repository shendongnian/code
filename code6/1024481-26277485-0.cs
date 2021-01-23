    public class Family
    {
        public string Name { get; set; }
        public Member Member {get;set;}
        public Family()
        {
            Member = new Member();
        }
    
    }
