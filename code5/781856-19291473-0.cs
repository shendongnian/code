    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)]bool fBlockIt);
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Show();
                //Blocks the input
                BlockInput(true);
                System.Threading.Thread.Sleep(5000);
                //Unblocks the input
                BlockInput(false); 
            }
        }
    }
