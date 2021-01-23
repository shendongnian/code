    public class PrmTbl_Staff
    {
        public int ID { get; set; }
        public int SalutationID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        
        //reference to Salutation
        public PrmTbl_Salutation Salutation {get; set;}
        //...
    }
