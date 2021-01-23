    public class MDIParent : Form
    {
        public void CreateChild()
        {
            ChildForm child = new ChildForm(this);
        }
        public string textboxvalue
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
    }
    public class ChildForm : Form
    {
        private Form _frmParent;
        public ChildForm(Form parent)
        {
            _frmParent = parent;
            // IntializeComponent();
        }
        public void SetText()
        {
            if (_frmParent != null)
            {
                _frmParent.textboxvalue = webBrowser1.Url.ToString();
            }
        }
    }
