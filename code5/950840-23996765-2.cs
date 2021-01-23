    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace testoForm
    {
        public partial class Form1 : Form
        {
            [DllImport("user32")]
            static extern UInt32 MapVirtualKey(UInt32 nCode, UInt32 uMapType);
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                ShowKey(e.KeyCode);
            }
            private void ShowKey(Keys key)
            {
                var keyCode = (UInt32)key;
                var scanCode = MapVirtualKey(keyCode, 0);
                var s = String.Format("VK = {0:X2}, SC={1:X2}", keyCode, scanCode);
                MessageBox.Show(s);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                ShowKey(Keys.Select);
            }
        }
    }
