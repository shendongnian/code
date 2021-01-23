    public class MyEntity
    {
       [NotMapped]
       public DateTime Time { 
         get{
          return Time.AsInt()  
         }
       
         set{
          TimeAsInt = value.AsInt();
         }
        [Column("Time")]
        public int TimeAsInt{get;set;}
    }
