    [DataContract]
    public class StudyPlanResponse
    {
        [DataMember(Name = "CODE")]
        public string Code { get; set; }            
        [DataMember(Name = "EXAMS_LIST")]
        public Dictionary<int, Exam> Exams { get; set; }
    }
