     //This extends the Entity Framework entity thanks to the `partial` keyword
     [MetadataType(typeof(ClientMetadata))]
     public partial class Client { }
     //This class applies metadata through data annotations that validates your model
     public partial class ClientMetadata{
         //Let's say we want to add a couple validation rule to the client's age 
         [Required(ErrorMessage="Age is required")]
         [Range(19,100,ErrorMessage="Your age must be between 19 and 100")] 
         public int Age { get;set; }
     }
