    using System;
    using System.Windows.Forms;
    namespace TestingFileOpenDialog
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                this.openFileDialog1.FileName = "pro*";
                this.openFileDialog1.Filter = "Pdf Files|*.pdf";
                this.openFileDialog1.ShowDialog();
            }
        }
    }
