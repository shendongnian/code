    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "0";
            Application.AddMessageFilter(this);
            
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201) //wm_lbuttondown
            {
                label1.Text = "" + (Int32.Parse(label1.Text) + 1);
            }
            return false;
        }
    }
