    public partial class FoodRegister : Form
    {
        private RecipeManager m_foodmanager = new RecipeManager();
        //MainForm mainform = null;
        public FoodRegister()
        {
            InitializeComponent();
            //My initializations
            InitializeGUI();
            //MainForm mainform = new MainForm(); 
            //No need to instantiate the form now, since your variable is static, 
            //which means it depends on the class not an instance of the class.
            Nametxt.Text = MainForm.myListBoxString;
        }
        private void InitializeGUI()
        {
        }
    }
