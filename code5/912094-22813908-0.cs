    public interface ISurvey<T>
        where T: ISurveyItem 
    {
        List<T> Items { get; set; }
        int QueueId { get; set; }
        SurveyType Type { get; set; }
    }
    public class Survey : ISurvey<SurveyItem>
    {
        public List<SurveyItem> Items { get; set; }
        public int QueueId { get; set; }
        public SurveyType Type { get; set; }
    }
