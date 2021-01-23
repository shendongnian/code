    public partial class Form1 : Form
    {
        Image CapturedImage;
        public Form1(Image imgObj) //"you need to pass _screenCap to the constructor of Form1"
        {
            InitializeComponent();
            CapturedImage = imgObj; //"which would need to store it in a field"
        }
    }
