    public class MyGridView : DataGridView
    {
        public MyGridView()
        {
            BackgroundColor = Color.Red;
        }
        [DefaultValue(typeof(Color), "Red")]
        public new Color BackgroundColor
        {
            get { return base.BackgroundColor; }
            set { base.BackgroundColor = value; }
        }
    }
