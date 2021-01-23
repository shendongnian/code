    public partial class TestForm : Form
    {
         public List<PictureBox> listPictureBox;
         PictureBox[] pictureBoxArray = default(PictureBox[]);
         public TestForm()
         {
             InitializeComponent();
             pictureBoxArray = new PictureBox[] {pictureBox1, pictureBox2, pictureBox3};
         }
         public static bool testMethod
         {
               listPictureBox = new List<PictureBox>();
             for(int i = 0; i < pictureBoxArray.length; i++) //The questionmarks should be pictureBoxArray.Length, but I don't know how to reach the code.
             {
                 listPictureBox.Add(pictureBoxArray[i]); //Same here, the questionmarks should be pictureBoxArray.
             }
         }
    }
