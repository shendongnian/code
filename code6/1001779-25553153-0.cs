    public sealed class TotalTimeChangedMessage
    {
        public string totalTime;
        public TotalTimeChangedMessage(string totalTime)
        {
            this.totalTime = totalTime;
        }
        public string TotalTime
        {
            get { return this.totalTime; }
        }
    }
