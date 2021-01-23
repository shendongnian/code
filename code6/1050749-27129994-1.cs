    public partial class Form1 : Form
    {
        LoopCounter counter = new LoopCounter();
    
        public Form1()
        {
            InitializeComponent();
    
            UpdateUI();
        }
    
        private void UpdateUI()
        {
            // update GUI
            btnUpdate.Text = "Hello # " + counter.Test.ToString() + "." + counter.Variation.ToString() + "." + counter.Subtest.ToString();
        }
    
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("I was clicked");
    
            if (counter.DoNext())
            {
                UpdateUI();
            }
            else
            {
                // done case
                Console.WriteLine("Tests are complete");
                btnUpdate.Visible = false;
            }
        }
    }
