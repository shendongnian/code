    public class vApplicationKey
    {
       public vApplicationKey
       {
         ApplicationId = System.Guid.NewGuid();
       }
     
     [Key]
     public System.Guid ApplicationId { get; set; }
     
    }
