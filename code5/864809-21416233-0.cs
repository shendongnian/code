    public class Connection
    {
        public event Action<string> MessageReceivedEvent;
        public void fire()
        {
            if (this.MessageReceivedEvent != null) MessageReceivedEvent("message");
        }
    }
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Connection con = new Connection();
            con.MessageReceivedEvent += new System.Action<string>(HandleMessage);
            
        }
 
        private void HandleMessage(string message)
        {
            //Update your textbox here
        }
        public Form1()
        {
            InitializeComponent();
            
        }
    }
