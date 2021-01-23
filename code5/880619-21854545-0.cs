    public void Main()
    {
    	Application.Run(new MyForm());
    }
    
    public class MyForm : Form
    {
    	public MyForm()
    	{
    		this.KeyDown += this.OnKeyDown;
    	}
    	
    	public void OnKeyDown(object sender, KeyEventArgs e)
    	{
    		e.Dump();
    	}
    }
