    public partial class Category
            {
                [Key]
                public int PersonCoursesId { get; set; }    
    
                [ForeignKey("Person")]    
                public int PersonId { get; set; }
    
                [ForeignKey("Course")]   
                public int CourseId { get; set; }            
            }
