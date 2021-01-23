    public class ClassifiedsDetails
    {
        public ClassifiedsDetails()
        {
          Model1 = new Classifieds();
          Model2 = new ClassifiedsComments();
        }
        public Classifieds Model1{ get; set; }   
        public ClassifiedsComments Model2{ get; set; }
    }
    public class Classifieds
    {
       public Classifieds()
       {
         C_Unique_Id = String.Emty;
         AdType = String.Emty;
         //---- Add default setting here------
       }
        [Key]
        public string C_Unique_Id { get; set; }
    
        public string AdType { get; set; }
    
        public string Title { get; set; }
    
        public string Description { get; set; }
    }
