    public class ChildForm1 : Form
    {
    	// Fields
    	private MainForm _mainForm;
    	private bool _value1;
    	private bool _value2;
    
    	// Default constructor
    	public ChildForm1()
    	{
    	}
    	
    	// Overloaded constructor that accepts a container of values
    	public ChildForm1(ValuesContainer values, MainForm mainForm)
    	{
    		_mainForm = mainForm;
    		_value1 = values.Value1;
    		_value2 = values.Value2;
    		
    		//Set a main form value
    		_mainForm.Value = "This value was changed by ChildForm1."
    	}
    }
    
    public class ChildForm2 : Form
    {
    	// Field
    	private bool _value3;
    
    	// Default constructor
    	public ChildForm2()
    	{
    	}
    	
    	// Overloaded constructor that accepts a container of values
    	public ChildForm2(ValuesContainer values)
    	{
    		_value3 = values.Value3;
    	}
    }
    
    public class MainForm : Form
    {
    	public string Value { get; set; }
    	
    	// Default constructor
    	public MainForm()
    	{
    	}
    	
    	// Simulated - Event method called when button is clicked for child form 1
    	public void CallChildForm1()
    	{
    		ValuesContainer values = new ValuesContainer();
    		
    		// Set the values from the main form
    		values.Value1 = true; 
    		values.Value2 = true; 
    		
    		// Call the child form while passing in the container of values that we just populated.
    		ChildForm1 childForm = new ChildForm1(values);
    		childForm1.Show();
    	}
    	
    	// Simulated - Event method called when button is clicked for child form 2
    	public void CallChildForm2()
    	{
    		ValuesContainer values = new ValuesContainer();
    		
    		// Set the value from the main form
    		values.Value3 = true; 
    		
    		// Call the child form while passing in the container of values that we just populated.
    		ChildForm2 childForm = new ChildForm2(values);
    		childForm2.Show();
    	}
    }
    
    // Simple data object or container used to transfer information between complex objects such as forms and controls.
    // These are also known as data classes or data transfer objects (DTOs)
    public class ValuesContainer
    {
    	public bool Value1 { get; set; }
    	public bool Value2 { get; set; }
    	public bool Value3 { get; set; }
    }
