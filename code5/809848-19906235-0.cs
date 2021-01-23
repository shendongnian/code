    public partial class Pop_up : Form
    {
        public Pop_up()
        {
            InitializeComponent();        
        }
        public Pop_up(string recipeName, DataSet dset)
        {
            InitializeComponent();
            BindDataContext(recipeName, dset);
        }
        private void BindDataContext(string recipeName, DataSet dset)
        {
            DataTable dataTable = dset.Tables[0];
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }
            FileStream FS1 = new FileStream("image.jpg", FileMode.Create);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow[0].ToString() == recipeName)
                {
                    byte[] blob = (byte[])dataRow[1];
                    FS1.Write(blob, 0, blob.Length);
                    FS1.Close();
                    FS1 = null;
                    labelIngredients.Text = dataRow[3].ToString();
                    labelCookSteps.Text = dataRow[2].ToString();
                    pictureBox.Image = Image.FromFile("image.jpg");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Refresh();
                }
            }
        } 
    }
