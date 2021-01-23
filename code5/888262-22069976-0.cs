    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool IgnoreKeys = false;
        private int target = 0;
        private int counter = 0;
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IgnoreKeys)
            {
                if (e.KeyData == Keys.D1)
                {
                    Send("simulate this text entry");
                }
                if (e.KeyData == Keys.F12)
                {
                    Send("123");
                }
            }
            else
            {
                counter++;
                if (counter == target)
                {
                    IgnoreKeys = false;
                }
            }
        }
        private void Send(string entry)
        {
            IgnoreKeys = true;
            counter = 0;
            target = entry.Length;
            SendKeys.Send(entry);
        }
    }
