    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public  Form2 frm2;
            public  Form3 frm3;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            public void updateText()
            {
                this.textBox1.Text = "";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (frm2 == null)
                    frm2 = new Form2(this);
                
                    frm2.ShowDialog();
            }
        }
    }
    
    
    using System;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form1 refToForm1;
    
            public Form2(Form1 f1)
            {
                refToForm1 = f1;
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (refToForm1.frm3 == null)
                    refToForm1.frm3 = new Form3(this);
    
                refToForm1.frm3.ShowDialog();
            }
    
            public void UpdateForm2(string txt)
        {
            this.textBox1.Text = txt;
        }
    
        }
    }
    
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form3 : Form
        {
            Form2 refToForm2;
            public Form3( Form2 f2)
            {
                refToForm2 = f2;
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Pass any data to Form1;
                refToForm2.refToForm1.updateText();
    
                //Pass data to form2
                refToForm2.UpdateForm2("from form3");
            }
        }
    }
