    public partial class FoodRegister : Form
    {
        private RecipeManager m_foodmanager = new RecipeManager();
        public FoodRegister() 
        {
            InitializeComponent();
            //My initializations
            InitializeGUI();
        }
        public void SetText(string txt)
        {
             Nametxt.Text = txt;
        }
    }
