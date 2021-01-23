    public class Student
        {
            public string Name { get; set; }
            public List<StudentLanguage> StudentLanguages { get; set; }
        }
    
        public class StudentLanguage
        {
            public string Name { get; set; }
            public string LanguageCode { get; set; }
            public int KnowledgeLevelId { get; set; }
        }
    
        public class LanguageKnowledge
        {
            public string LanguageCode { get; set; }
            public int KnowledgeLevelId { get; set; }
        }
