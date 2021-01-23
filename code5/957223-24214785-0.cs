    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        updateForm Uform;
        private void cb_update_Click(object sender, EventArgs e)
        {
            if (Uform == null)  Uform = new updateForm(this);
            Uform.Show();
        }
    }
    public partial class updateForm : Form
    {
        mainForm main_Form;
        public updateForm(mainForm main)
        {
            InitializeComponent();
            main_Form = main;
        }
        private void updateForm_Shown(object sender, EventArgs e)
        {
            this.Size = main_Form.Size;
            this.Location = main_Form.Location;
            setControlState(main_Form, false);
        }
        private void cb_back_Click(object sender, EventArgs e)
        {
            setControlState(main_Form, true);
            this.Hide();
        }
        private void updateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            setControlState(main_Form, true);
            this.Hide();
        }
        public void setControlState(Control Ctl, bool enabled)
        {
            foreach (Control c in Ctl.Controls) setControlState(c, enabled);
            Ctl.Enabled = enabled;
        }
    }
