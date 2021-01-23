    public partial class Form1 : Form
    {
        bool Clicked; //Create this Class level variable to be used in your handler
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBoxCapture_Click(object sender, EventArgs e)
        {
            Clicked =! Clicked; //Toggle your Boolean here
            try
            {
                if (Clicked)
                {
                    Application.Idle -= ProcessFrame;
                    FaceDetect();
                }
                else
                {
                    Application.Idle += ProcessFrame;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
