    public class RankItem
    {
        public Guid ModID { get; set; }
        public string Code { get; set; }
        public string RankName { get; set; }
        public int? Priority { get; set; }
    
        publist DataFields<string>  {get;set;}  // I want to add dynamic field
        //publist DataFields<int>  {get;set;}  // I want to add dynamic field
    }
