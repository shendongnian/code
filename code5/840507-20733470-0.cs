    public partial class Form1 : Form
    {
    	private int _charCode = 65;
    
    	public Form1()
    	{
    		InitializeComponent();
    		alphaCode.Text = "-";
    	}
    
    	private void alphaCode_Click(object sender, EventArgs e)
    	{
    		// 90 is 'Z'
    		if (_charCode <= 90)
    		{
    			alphaCode.Text = ((char)_charCode).ToString();
    			_charCode++;
    		}
    	}
    }
