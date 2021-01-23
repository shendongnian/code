    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //This is your Event, Call this to send message
        public event EventHandler myEvent;
        private void Form1_Load(object sender, EventArgs e)
        {
             //How to call your Event
            if(myEvent != null)
                myEvent(this, new MyEventArgs() { Message = "Here is a Message" });
        }
    }
    //Your event Arguments to pass your message
    public class MyEventArgs : EventArgs
    {
        public String Message
        {
            get;
            set;
        }
    }
