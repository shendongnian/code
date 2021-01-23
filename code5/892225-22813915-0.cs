    public abstract class BaseModel : ISoftDelete {
        public BaseModel() { }
        public int id { get; set; }
    }
    
    public class Course : BaseModel {
        public Course() { }
        [Required]
        public int presentationId { get; set; }
        public virtual Presentation presentation { get; set; }
    }
