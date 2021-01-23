       public Form1 Caller = null;
    
       public Form2()
       {
           InitializeComponent();
       }
    
            
    
       private void btnTest_Click(object sender, EventArgs e)
       {
            Caller.textBox1.Text = "HEllo Word";
       }
}
