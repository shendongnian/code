    public class ButtonEx : Button
    {
        public int ClickCount { get; private set; }
        public ButtonEx()
        {
            this.Click += (s, e) => { ++this.ClickCount; };
        }
        public void ResetPressCount()
        {
            this.ClickCount = 0;
        }
    }
