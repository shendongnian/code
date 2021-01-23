    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        //...
        //method implementation of the interface IMessageFilter
        public bool PreFilterMessage(ref Message m)
        {
            //WM_LBUTTONDBLCLK = 0x203
            if (m.Msg == 0x203) {
                //your code goes here...
                timer1.Stop();
                timer1.Start();
            }
            return false;
        }
    }
