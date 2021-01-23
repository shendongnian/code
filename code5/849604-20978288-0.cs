    namespace showimage
    {
        public partial class Form1 : Form
        {
            private List<ImagePicker> image_list;
            public Form1()
            {
                InitializeComponent();
                image_list = new List<ImagePicker>();
                // Add the images - creating an ImagePicker object per file
                image_list.Add(new ImagePicker("Photo1", "photo1.jpg"));
                image_list.Add(new ImagePicker("Photo2", "photo2.jpg"));
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                listBox1.Items.AddRange(image_list.ToArray());
            }
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                ImagePicker picked_image = (ImagePicker)listBox1.SelectedItem;
                pictureBox1.Load(picked_image.filename);
            }
        }
        public class ImagePicker
        {
            private string _name;
            private string _filename;
            public string filename 
            {
                get 
                {
                    return _filename;
                }
            }
            public ImagePicker(string name, string filename)
            {
                _name = name;
                _filename = filename;
            }
            public override string ToString()
            {
 	             return _name;
            }
        }
    }
