    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(new DoubleClickSuppressser());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            f2.Show();
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("listBox1 DoubleClick");
        }
    }
    public class DoubleClickSuppressser : IMessageFilter
    {
        private int difference;
        private DateTime Last_LBUTTONDOWN = DateTime.MinValue;
        private const int WM_LBUTTONDOWN = 0x201;
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                    if (Control.FromHandle(m.HWnd) is Button)
                    {
                        if (!Last_LBUTTONDOWN.Equals(DateTime.MinValue))
                        {
                            difference = (int)DateTime.Now.Subtract(Last_LBUTTONDOWN).TotalMilliseconds;
                            Last_LBUTTONDOWN = DateTime.Now;
                            if (difference < System.Windows.Forms.SystemInformation.DoubleClickTime)
                            {
                                return true;
                            }
                        }
                        Last_LBUTTONDOWN = DateTime.Now;
                    }
                    break;
            }
            return false;
        }
    }
