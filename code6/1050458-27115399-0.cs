    public partial class UpgradeForm : Form
    {
        private GameForm gF;
        List<Helicopter> HeliList = new List<Helicopter>();
    
        public UpgradeForm(List<Helicopter> list)
        {
            InitializeComponent();
   
            HeliList.AddRange(list);
        }
    }
