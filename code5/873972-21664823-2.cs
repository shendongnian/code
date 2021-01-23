    //Changing database table name to Metadata
    [Table("Metadata")]
    public class Metadata 
    {
      [Required, Key]
      public int MetadataId { get; set; }
      [Required, ScaffoldColumn(false)]
      public int DocumentId { get; set; }
      [Required, StringLength(250), DataType(DataType.Text)]
      public string Title { get; set; 
    }
