        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        namespace PeeAlyser.Forms
        {
          public partial class AreaSelector : Form
           {
        #region Variables
        Bitmap originalImage, modifiedImage;
        string fileName;
        #endregion
        #region Constructors
        public AreaSelector(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
        }
        #endregion
	public int access=1;
        private void AreaSelector_Load(object sender, EventArgs e)
        {
            TryToLoadImage();
            if(access==1)
	    {
	    	UpdateWindowSize();
            	UpdatePictureBox();
	    }
        }
        #region Private Methods
        private void Abort()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BeginInvoke(new MethodInvoker(this.Close));
            //this.Close();
            //this.Dispose();
            // GODAMNIT!
        }
        private void TryToLoadImage()
        {
            if (!System.IO.File.Exists(fileName))
            {
		access=0;
                MessageBox.Show("File not found.");
                Abort();
            }
            try { originalImage = (Bitmap)Bitmap.FromFile(fileName); }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + Environment.NewLine +
                                error.ToString());
                Abort();
            }
            this.modifiedImage = new Bitmap(originalImage);
        }
        private void UpdateWindowSize()
        {
            int widthDifference = this.Width - pictureBox1.Width;
            int heightDifference = this.Height - pictureBox1.Height;
            Size windowSize = originalImage.Size;
            windowSize.Width += widthDifference;
            windowSize.Height += heightDifference;
            this.Size = this.MinimumSize = this.MaximumSize = windowSize;
            this.pictureBox1.Size = originalImage.Size;
            this.AdjustFormScrollbars(true);
        }
        private void UpdatePictureBox()
        {
            this.pictureBox1.Image = modifiedImage;
            this.Refresh();
        }
        #endregion
    }
    }
