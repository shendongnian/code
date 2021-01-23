    public class Exam
    {
        public int ExamId { get; set; }
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
    }
    
    public class Test
    {
        public int TestId { get; set; }
        public int ExamId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<UserTest> UserTests { get; set; }
    }
    
    public class UserTest
    {
        public int UserTestId { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public int QuestionsCount { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
