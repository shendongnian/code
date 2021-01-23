    public sealed class DownloadFinishedEvent
    {
        public readonly string EventText = "Download Completed";
        // Additional Download Info Here.
        public override string ToString()
        {
            return this.EventText;
        }
    }
