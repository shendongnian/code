    public class ClassifiedsDetails
        {
            public ClassifiedsDetails()
            {
              Model1 = new Classifieds();
              Model2 = new List<ClassifiedsComments>();
            }
            public Classifieds Model1{ get; set; }   
            public List<ClassifiedsComments> Model2{ get; set; }
        }
