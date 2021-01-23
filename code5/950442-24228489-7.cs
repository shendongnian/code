     public class ChatHistoryManager
    {
        private readonly RichTextBox richTextBox;
        private Timer timer = new Timer();
        public ChatHistoryManager(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            this.InitializeTimer();
        }
        public string Location { get; set; }
        private void InitializeTimer()
        {
            this.timer.Tick += timer_Tick;
            this.timer.Enabled = true;          
            this.timer.Interval = (int) TimeSpan.FromHours(1).TotalMilliseconds;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.SaveFile();
        }
        public void SaveFile()
        {
            //Save the file to the location
            this.richTextBox.SaveFile(this.Location,RichTextBoxStreamType.RichText);
        }
        public void Stop()
        {
            this.timer.Stop();
        }
    }
