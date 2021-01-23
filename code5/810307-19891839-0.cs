    public partial class AdditionalForm : Form
    {
        private Label l_dataToShow;
        public Label DataToShow { get { return l_dataToShow; } }
        public AdditionalForm()
        {
            InitializeComponent();
            SuspendLayout();
            l_dataToShow = new Label();
            l_dataToShow.AutoSize = true;
            l_dataToShow.Location = new Point(12, 9);
            l_dataToShow.Size = new Size(40, 13);
            l_dataToShow.TabIndex = 0;
            l_dataToShow.Text = "Data will be shown here";
            Controls.Add(l_dataToShow);
            ResumeLayout();
        }
    }
    public partial class MainForm : Form
    {
        private AdditionalForm af;
        public MainForm()
        {
            InitializeComponent();
            SuspendLayout();
            txtbx_data = new TextBox();
            txtbx_data.Location = new System.Drawing.Point(12, 12);
            txtbx_data.Name = "txtbx_data";
            txtbx_data.Size = new System.Drawing.Size(100, 20);
            txtbx_data.TabIndex = 0;
            Controls.Add(txtbx_data);
            ResumeLayout();
            txtbx_data.TextChanged += new EventHandler(txtbx_data_TextChanged);
            af = new AdditionalForm();
            af.Show();
        }
        /// <summary>
        /// The data that contains textbox will be transfered to another form to a label when you will change text in a textbox. You must make here your own event that will transfer data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_data_TextChanged(object sender, EventArgs e)
        {
            af.DataToShow.Text = txtbx_data.Text;
        }
    }
