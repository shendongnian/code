    public class ExtendedTextBox : System.Windows.Forms.TextBox
    {
        private int? _Address = null;
        [Description("Address of variable")]
        [DefaultValue(null)]
        public int? Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
