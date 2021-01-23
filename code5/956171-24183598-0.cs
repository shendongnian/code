    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
                Panel pnl = new Panel();
                pnl.Dock = DockStyle.Fill;
                pnl.BackgroundImage = System.Drawing.Image.FromFile("D:\\Picture\\Graphic\\2\\(1).png");//address of your image
                pnl.BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(pnl);
            }
        }
    }
