    public partial class Form1 : Form
    {
    	private string _line;
    	public string Line
    	{
    		get { return _line; }
    		set { _line = value; }
    	}
    	private void button2_Click(object sender, EventArgs e)
    	{
    		Line = "cake";
    		MessageBox.Show(Line);
    	}
    }
