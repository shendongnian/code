    public partial class ParentForm : Form
    {
    	public ParentForm()
    	{
    		InitializeComponent();
    	}
    	private void button2_Click(object sender, EventArgs e)
    	{
    		ChildForm c = new ChildForm();
    		c.StringValue = "TADA";
    		c.IntValue = 42;
    		c.Show();
    	}
    }
    
    
    public partial class ChildForm : Form
    {
    	public string StringValue{get; set;}
    	public int IntValue { get; set; }
    
    	public ChildForm()
    	{
    		InitializeComponent();
    	}
    }
