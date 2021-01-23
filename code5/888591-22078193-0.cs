    public partial class ChampionSelect : Form
    {
    	Main champSlct;
    
        public ChampionSelect(Main main)
        {
            InitializeComponent();
            this.champSlct = main;
        }
    	
        public void icon_slctAce_Click(object sender, EventArgs e)
        {
            champSlct.ChampionSelect = Properties.Resources.Ace;
        }
    }
    
    public partial class ChampionSelect : Form
    {
    	public Image ChampionSelect
    	{
    		get { return pictureBox_championSelect.Image; }
    		set { pictureBox_championSelect.Image = value; }
    	}
    	
    	private void pictureBox_championSelect_Click(object sender, EventArgs e)
    	{
    		using (var champSlct = new ChampionSelect(this))
    		{
    			champSlct.Show();
    		}		
    	}
    
    	/* ... */
    }
