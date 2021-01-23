    public System.Windows.Forms.Form MyParent;
    
    string s = textBox1.Text;
    Form1 f1 = (Form1)this.MyParent;
    f1.panel1.Visible = false;
    f1.textBox1.Text = s;
