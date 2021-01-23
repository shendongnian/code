    [DataContract]
    public class User
    {
        [DataMember]
        public IEnumerable<Exam> Exams {get; set;}
    }
    
    [DataContract]
    public class Exam
    {
       [DataMember]
       public int Score {get; set;}
    }
