    public class Form1 : System.Windows.Forms.Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
            {
    		Form2 tmpFrm = new Form2();
    		tmpFrm.txtboxToSetReadOnly = this.txtMyTextBox; //send the reference of the textbox you want to update
    		tmpFrm.ShowDialog(); // tmpFrm.Show();
    	}
    }
 
