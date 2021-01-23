    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Form2 frm = new Form2();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                frm.Show();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                frm.SetTextLabel1("Hello world");
                //or
                frm.Label1Text = "HEllo world again";
            }
        }
    }
    
    
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            //using method to set the value of label
            public void SetTextLabel1(string value)
            {
                
                label1.Text = value;
            }
    
            //using property to set the value of label
            public string Label1Text
            {
                set { label1.Text = value; }
            }
        }
    }
