    public PictureDisplay()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog newDialog = new OpenFileDialog();
            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picBoxDisplay.Load(newDialog.FileName);
                    picBoxDisplay.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    MessageBox.Show("Wrong file type!", "Error");
                }
            }
        }
