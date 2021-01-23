    public class ExamDTO
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        // no Tests collection here
    }
    public class TestDTO
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        // no UserTests collection here
        public ExamDTO Exam { get; set; }
    }
    public class UserTestDTO
    {
        public int UserTestId { get; set; }
        public string UserId { get; set; }
        public int QuestionsCount { get; set; }
        public TestDTO Test { get; set; }
    }
