     public class ServiceForm
            {
                [Required]
                [Display(Name="Student Number")]
                public int student_number { get; set; }
                [Required]
                [Display(Name="Program")]
                public SelectList Programs { get; set; }
        
                public string SelectedProgram { get; set; }
        
                [Required]
                [Display(Name = "Title")]
                public string title { get; set; }
                [Required]
                [Display(Name = "Description")]
                public string description { get; set; }
                [Required]
                [Display(Name = "Category")]
                public SelectList Categories{ get; set; }
        
                public string SelectedCategory { get; set; }
        
            }
