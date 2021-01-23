    namespace MyProject.Models
    {
      public class MyModel
      {
        [Required]
        [Display(Name = "State")]
        public string StatePick { get; set; }
        public string state { get; set; }
        [StringLength(35, ErrorMessage = "State cannot be longer than 35 characters.")]
        public SelectList StateList { get; set; }
      }
    }
