    public partial class Form1 : Form
    {
      // This is you constructor (not shown in your sample code).
      public Form1()
      {
        InitializeComponent();
        Instance = this;
      }
    
      public static Form1 Instance { get; private set;}
    
      game_rule dt = new game_rule();
      private void button2_Click(object sender, EventArgs e)
      {
        progressBar1.Increment(-200); // this is work
        dt.DoAttack(); // this is not work... but there is no build error at all!
      }
    }
    
    
    class game_rule
    {
        public void DoAttack()
        {
            Form1.Instance.progressBar1.Increment(-200);
            SystemSounds.Asterisk.Play();
        }
    }
