    using System;
    using System.Windows.Forms;
    namespace ClassLibrary1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void button1_Click(object sender, EventArgs e)
            {
                ClassLibrary1.WCFServiceLibrary1 client = new ClassLibrary1.WCFServiceLibrary1();
                label1.Text = client.GetData(textBox1.Text);
            }
        }
    }
