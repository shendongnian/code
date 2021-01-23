    public class CourseSection
    {
        [Key]
        public int CourseSectionID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<SectionContent> SectionContents { get; set; }
    }
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
    }
