	public partial class BrowserForm : Form
    {
        public BrowserPanel Panel { get; private set; }
        public BrowserForm(BrowserPanel panel)
        {
            Panel = panel;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
        }
	}
