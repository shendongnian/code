    class SubscribedProgram
    {
        public DateTime StartTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public object LinkedProgram { get; set; }
        public SubscribedProgram(object linkedProgram)
        {
            this.LinkedProgram = linkedProgram;
        }
        public void programActivated()
        {
            this.StartTime = DateTime.Now;
        }
        public void programDeactivated()
        {
            // If this was the first deactivation, set totalTime
            if (this.TotalTime == TimeSpan.MinValue) { this.TotalTime = DateTime.Now.Subtract(this.StartTime); }
            // If this is not the first calculation, add older totalTime too
            else { this.TotalTime = this.TotalTime + (DateTime.Now.Subtract(this.StartTime)); }
        }
    }
