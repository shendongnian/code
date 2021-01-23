    [System.ComponentModel.DesignerCategory("Code")]
    public class MyLabel : Label
    {
        [DefaultValue(true)]
        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        public MyLabel()
        {
            AutoSize = true;
        }
    }
