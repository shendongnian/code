    public static class stat
        {
            public static void GetValidationList(  this AcObject source )
            {
                Console.WriteLine(source.Id);
                
            }
        }
    
    
        public class AcObject
    {
        public int Id { get; set; }
    }
