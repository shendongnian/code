    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public SelectList Courses { get; set; }
    }
