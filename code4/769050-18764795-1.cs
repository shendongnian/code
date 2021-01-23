    public class ProgressInfo 
    {
        private int progressPercentage;
        public ProgressInfo() {}
        public ProgressInfo(int progressPercentage)
        {
            this.progressPercentage = progressPercentage;
        }
        public int ProgressPercentage
        {
            get { return progressPercentage; }
            set { progressPercentage = value; }
        }
    }
