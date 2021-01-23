    public partial class formSouthPark : Form
    {
        public formSouthPark()
        {
            InitializeComponent();
        }
        // These variables need to be declared outside both function scopes.
        int originalHeight;
        int originalWidth;
        public void formSouthPark_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Snow;
            originalHeight = pictureEric.Height;
            originalWidth = pictureEric.Width;
        }
        private void buttonRestoreEric_Click(object sender, EventArgs e)
        {
            pictureEric.Height = originalHeight;
            pictureEric.Width = originalWidth;
        }
    }
