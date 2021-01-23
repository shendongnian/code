    public class QuestionTypeA 
    {
        public int ID { get; set;}
        public string Name { get; set; }
    }
    public class QuestionTypeB
    {
        public int ID { get; set;}
        public DateTime Date { get; set; }
    }
    public class QuestionTypeC
    {
        public int ID { get; set;}
        public int NumericData { get; set; }
    }
    public class ViewModel
    {
        public List<QuestionTypeA> QuestionAs { get; set; }
        public List<QuestionTypeB> QuestionBs { get; set; }
        public List<QuestionTypeC> QuestionCs { get; set; }
    }
