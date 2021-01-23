    public partial class Form1 : Form
    {
        private ImageMutator mutator ;/private member "has-a" relationship
        public Form1()
        {
            InitializeComponent();
            mutator = new ImageMutator(pictureBox);//whatever image type is
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            mutator.ConfirmChange();//Only saves if mutation occurred         
        }
    }
