    public class CategoryMaster
    {
       [Key]
        public long CategoryID { get; set; }
       [Required]
        public string CategoryName { get; set; }
         [Required]
        public string CategoryType { get; set; }
        
    }
