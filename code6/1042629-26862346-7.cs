    public partial class MainForm : Form
    {
        public MainForm()
        {InitializeComponent();}
    
        public string Change
        {
            get{ return label.Text;}
            set{ label.Text = value;}
        }
    
         void ButtonClick(object sender, EventArgs e)
        {
            Test a = new Test(this);
            a.changer();
    
    
        }
    }}
