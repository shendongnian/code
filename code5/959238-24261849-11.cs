    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("user32.dll")]
            static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
            public enum SystemIconIds
            {
                IDI_APPLICATION = 32512,
                IDI_HAND = 32513,
                IDI_QUESTION = 32514,
                IDI_EXCLAMATION = 32515,
                IDI_ASTERISK = 32516,
                IDI_WINLOGO = 32517,
                IDI_WARNING = IDI_EXCLAMATION,
                IDI_ERROR = IDI_HAND,
                IDI_INFORMATION = IDI_ASTERISK,
            }
    
            public Form1()
            {
                InitializeComponent();
                // Information, Question and Asterix differ from the icons displayed on MessageBox
    
                // get icon from SystemIcons
                pictureBox1.Image = SystemIcons.Asterisk.ToBitmap();
                // load icon by ID
                IntPtr iconHandle = LoadIcon(IntPtr.Zero, new IntPtr((int)SystemIconIds.IDI_ASTERISK));
                pictureBox2.Image = Icon.FromHandle(iconHandle).ToBitmap();
            }
            private void pictureBox1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("test", "test caption", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                var hwnd = FindWindow(null, "test caption");
                if (hwnd != IntPtr.Zero)
                {
                    // we got the messagebox, get the icon from it
                    IntPtr hIconWnd = GetDlgItem(hwnd, 20);
                    if (hIconWnd != IntPtr.Zero)
                    {
                        var iconHandle = SendMessage(hIconWnd, 369/*STM_GETICON*/, IntPtr.Zero, IntPtr.Zero);
                        pictureBox3.Image = Icon.FromHandle(iconHandle).ToBitmap();
                    }
                }
            }
        }
    }
