    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : DockContent
        {
            public Form1()
            {
                InitializeComponent();
                label1.Text = "init";
                KeyPress += MainForm_KeyPress;
                KeyUp += MainForm_KeyUp;
                MouseDown += MainForm_MouseDown;
            }
            private void MainForm_MouseDown(object sender, MouseEventArgs e)
            {
                label1.Text = "MainForm_MouseDown";
            }
            private void MainForm_KeyUp(object sender, KeyEventArgs e)
            {
                label1.Text = "MainForm_KeyUp";
            }
            private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
            {
                label1.Text = "MainForm_KeyUp";
            }
        }
    }
