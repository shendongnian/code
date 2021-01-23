    public partial class Form1 : Form
    {
      game_rule dt = new game_rule();
      private void button2_Click(object sender, EventArgs e)
      {
        progressBar1.Increment(-200); // this is work
        dt.DoAttack(this); // this is not work... but there is no build error at all!
      }
    }
    
    
    class game_rule
    {        
        public void DoAttack(Form1 form)
        {
            form1.progressBar1.Increment(-200);
            SystemSounds.Asterisk.Play();
        }
    }
