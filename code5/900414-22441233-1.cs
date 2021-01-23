    namespace NumbertoWordHamza
    {
        public partial class Form1 : Form
    	{
    	    public Form1()
    	    {
    	        InitializeComponent();
    	    }
    
    	    private void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
    	    {
    	        if (!Information.IsNumeric(TextBox1.Text))
    	        {
    		        TextBox2.Text = "";
    		        return;
    		    }
    		    TextBox2.Text = GetTextForNumber(TextBox1.Text);
    	    }	
    	}
    }
