    public class FileStore
     {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public Guid Id { get; set; }
       public string Name { get; set; }
       public string Path { get; set; }
     }
