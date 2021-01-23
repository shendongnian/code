    public class Form1 : Form 
    {
        
        public Form1()
        {
            rb1.CheckedChanged += rb_CheckedChanged;
            rb2.CheckedChanged += rb_CheckedChanged;
            rb3.CheckedChanged += rb_CheckedChanged;
        } 
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!((Radiobutton)sender).Checked) return;
            if (cmbLetterType.Text.Length != 0)
            {
                updatePrintedCntLabel();
            }
          
        }
    }
