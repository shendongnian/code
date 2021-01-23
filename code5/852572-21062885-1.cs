     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
    namespace GRP_02_03_SACP
    {
    public partial class page_two : Form
    {
        private Int JopPosition;
        public page_two()
        {
            InitializeComponent();
        }
        public page_two(Int _Position)
        {
            InitializeComponent();
            JopPosition = _Position;
        }
        private void btnDoctor1_Click(object sender, EventArgs e)
        {
        }
        private void btnDoctor2_Click(object sender, EventArgs e)
        {
        }
        private void btnNurse1_Click(object sender, EventArgs e)
        {
            if (JopPosition == 1)
            {
               MessageBox.Show("access denied");
            }
        }
        private void btnNurse2_Click(object sender, EventArgs e)
        {
        }
    }
}
