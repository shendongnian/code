    public partial class Form1 : Form
    {
        private ImageMutator mutator = new ImageMutator();//private member "has-a" relationship
        public Form1()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            mutator.ConfirmChange();//Only saves if mutation occurred         
        }
    }
