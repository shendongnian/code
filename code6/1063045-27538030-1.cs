    class LineStorer
    {
    	private string _line;
    	public string Line
    	{
    		get { return _line; }
    		set { _line = value; }
    	}
    }
    
    public partial class Form1 : Form
    {
    	private void button2_Click(object sender, EventArgs e)
    	{
    		var storer = new LineStorer();
    		storer.Line = "cake";
    		MessageBox.Show(storer.Line);
    	}
    }
