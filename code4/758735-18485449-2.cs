    public class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            control.btnOKClicked += Control_buttonOk;
            control.btnCancelClicked += Control_buttonCancel;
        }
        private void Control_buttonOk(object sender, eventArgs e)
        {
            // implement code
        }
        private void Control_buttonCancel(object sender, eventArgs e)
        {
            // implement code
        }
    }
    public class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            btnOK.Click += (sender, e) =>
            {
                if(btnOKClicked != null)
                    btnOKClicked(this, EventArgs.Empty);
            };
            btnCancel.Click += (sender, e) =>
            {
                if(btnCancelClicked!= null)
                    btnCancelClicked(this, EventArgs.Empty);
            };
        }
        public event EventHandler btnOKClicked;
        public event EventHandler btnCancelClicked;
    }
