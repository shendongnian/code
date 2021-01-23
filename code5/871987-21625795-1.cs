    interface ISalaryScoreElement
    {
        int SalaryScore { get; }
        //Newly Added
        int OccurenceCount { get; set; }
    }
    public class BasicElement : ISalaryScoreElement
    {
        public int SalaryScore
        {
            get
            {
                return 100;
            }
        }
        public int OccurenceCount { get; set; }
    }
    public class StandardPointElement : ISalaryScoreElement
    {
        public int SalaryScore
        {
            get
            {
                return 10;
            }
        }
        public int OccurenceCount { get; set; }
    }
