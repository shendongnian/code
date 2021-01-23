    public class LabelEx : Label
    {
        public int ClickCount { get; private set; }
        public LabelEx()
        {
            this.MouseClick += (s, e) => { ++this.ClickCount; };
        }
        public void ResetPressCount()
        {
            this.ClickCount = 0;
        }
    }
