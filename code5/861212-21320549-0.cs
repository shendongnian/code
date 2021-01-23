    public class DataModel
      {
        [StringLength(2000, ErrorMessage = "Field cannot exceed 2000 characters")]
        public string Description { get; set; }
      }
