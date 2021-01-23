    public partial class MainForm : Form
    {
        public delegate void OnMyTextChanged(string value);
        public delegate void ButtonClicked(object sender, EventArgs e);
        public static event OnMyTextChanged OnChildTextChanged;
        public static event ButtonClicked OnButtonClick;
        ChildForm frm = new ChildForm();
        public MainForm()
        {
            InitializeComponent();
            frm.Show();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            OnChildTextChanged("this is new value");
            OnButtonClick(sender, e);
        }
    }
