    //  This is in form 1
    public partial class MainForm : Form
    {
        // You only need to instantiate food once
        private FoodRegister food = new FoodRegister();
    
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (food != null)
            {
                food.Show();
            }
        }
        private void Animallst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Animallst.SelectedIndex > -1)
            {
                if (food != null)
                {
                    food.AddToTextBox(Animallst.SelectedItem.ToString());
                }
            }
            else
            {
                // This will clear the text box on form 2
                food.AddToTextBox(string.Empty);
            }
        }
    }
    // This is in form 2
    public partial class FoodRegister : Form
    {
        public FoodRegister() 
        {         
            InitializeComponent();
        }
        public void AddToTextBox(string selectedItem)
        {
            Nametxt.Text = selectedItem;
        }
    }
