    public interface Subject<out TCourse> where TCourse : Course
    {
       int SubjectId { get; set; }
       string Name { get; set; }
       IEnumerable<TCourse> Courses { get; set; }
    }
