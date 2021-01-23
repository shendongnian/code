    public partial class TestForm : Form
    {
        public static List<PictureBox> listPictureBox;
    
        // Make this instance variable public 
        public  PictureBox[] pictureBoxArray;
    
        public TestForm()
        {
            InitializeComponent();
    
            // prepare the array with the 3 local pictureboxes
            pictureBoxArray = new PictureBox[] {pictureBox1, pictureBox2, pictureBox3};
        }
    
        // Calling this method requires that you pass the form instance where the 3 pictureboxes 
        // have been created
        public static bool testMethod(TestForm instance)
        {
            listPictureBox = new List<PictureBox>();
    
            for(int i = 0; i < instance.pictureBoxArray.Length; i++) 
            {
                listPictureBox.Add(instance.pictureBoxArray[i]; 
            }
        }
    
    }
