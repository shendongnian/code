    public class LableAndTextBox : UserControl
    {
     public LableAndTextBox()
     {
       InitializeComponents();
     }
    
     public void label_Click(object sender, EventArgs e)
     {
       textBox.Text = string.Empty;
     }
    }
