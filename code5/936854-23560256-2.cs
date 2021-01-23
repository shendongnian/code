    public partial class Student
    {
        public Student()
        {
            this.Scores = new HashSet<Score>();
        }
        public int Id { get; set; }
        public HttpPostedFileBase ImageUrl { get; set; }
        ...
