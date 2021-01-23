    public class Progress
    {
        private string sLabel = null;
        public string Label
        {
            get { return this.sLabel; }
            set { this.sLabel = value; }
        }
        private int iValue = -1;
        public int Value 
        {
            get { return this.iValue ; }
            set { this.iValue = value; }
        }
        public Progress()
        {
        }
        public Progress(string Label, int Value)
        {
            this.sLabel = Label;
            this.iValue = Value;
        }
    }
