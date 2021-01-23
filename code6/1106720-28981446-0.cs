    public class SubType
    {
      [HiddenInput(DisplayValue = false)]
      [Key]
      public int Id { get; set; }
      
      [Required(ErrorMessage = "Naam is verplicht")]
      public string Naam { get; set; }
    
      [Required(ErrorMessage = "Type is verplicht")]
      public int TypeID { get; set; }
    
      [ForeignKey("TypeID")]
      public virtual BType Type { get; set; }
    }
