    public partial class Form2 : Form
    {
        public static Image Image {get; set;}
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = Image;
        }
    }
 
