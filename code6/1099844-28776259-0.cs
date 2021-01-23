    public class PurposeVM
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
    public class ItemVM
    {
      public int Id { get; set; } // only required for an edit view model
      [Required]
      public string Name { get; set; }
      public List<PurposeVM> Purposes { get; set; }
