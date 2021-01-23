    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private AvailableImages _availableImages;
        private class AvailableImages
        {
            private List<string> _images;
            private int _selectedImage;
            public AvailableImages(IEnumerable<string> images, string selectedImage = null)
            {
                _images = images.ToList();
                _selectedImage = selectedImage == null ? 0 : _images.IndexOf(selectedImage);
            }
            public Bitmap GetNextImage()
            {
                _selectedImage++;
                if (_selectedImage >= _images.Count)
                {
                    _selectedImage = 0;
                }
                return new Bitmap(_images[_selectedImage]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "All|*.jpg;*.bmp;*.gif;*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                    _availableImages = new AvailableImages(System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(dlg.FileName)).Where(m => m.ToUpper().EndsWith("JPG") || m.ToUpper().EndsWith("BMP") || m.ToUpper().EndsWith("GIF") || m.ToUpper().EndsWith("PNG")), dlg.FileName);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = _availableImages.GetNextImage();
        }
    }
