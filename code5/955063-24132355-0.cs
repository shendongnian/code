    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace MaskedTextBox
    {
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                maskedTextBox1.Mask = "(00) 0000-00000";
                maskedTextBox1.BackColor = Color.LightYellow;
            }
        }
        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.BackColor = Color.LightBlue;
        }
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                maskedTextBox1.BackColor = Color.LightGreen;
            }
            else
            {
                maskedTextBox1.Mask = "(00) 0000-0000";
                maskedTextBox1.BackColor = Color.LightGreen;
            }
            if (!maskedTextBox1.MaskCompleted)
            {
                maskedTextBox1.BackColor = Color.LightCoral;
            }
        }
    }
    }
