    public class Player
    {
       public int Money { get; set; }
    }
    public MainForm : Form
    {
      private Player player1;
      public void Init()
      {
         this.player1 = new Player();
      }
    
      public void Main()
      {
         this.player1.money = 9001;
      }
    
      private void mainForm_Load(object sender, EventArgs e)
      {
        Init();
        Main();
      }
    }
