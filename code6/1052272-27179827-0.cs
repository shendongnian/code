    public partial class PlayerInfo : Form 
    { 
        private readonly GameScreen _main;
        public PlayerInfo(GameScreen main) 
        {
            _main = main;
            InitializeComponent();        
         }
        public void ConfirmPlayerInfo_Click(object sender, EventArgs e)
        {
            gm.P1Class = P1ClassChoice.Text;
            gm.P1Name = P1TextBox.Text;
            gm.P2Class = P2ClassChoice.Text;
            gm.P2Name = P2TextBox.Text;
            main.P1NameLabel.Text = gm.P1Name;
            main.P1ClassLabel.Text = gm.P1Class;
            main.P2NameLabel.Text = gm.P2Name;
            main.P2ClassLabel.Text = gm.P2Class;  
                   
        }
    }
