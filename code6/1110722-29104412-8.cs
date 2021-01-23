    public partial class Simulare : Form
    {
    	public Simulare()
    	{
    		InitializeComponent();
    		this.categoryTextBox.Text = "None";
    	}
    
    	public Simulare(string category)
    	{
    		InitializeComponent();
    		this.categoryTextBox.Text = category;
    	}
    
    	public string Category
    	{
    		get
    		{
    			return this.categoryTextBox.Text;
    		}
    		set
    		{
    			this.categoryTextBox.Text = value;
    		}
    	}
    }
