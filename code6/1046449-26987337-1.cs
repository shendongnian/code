    FolderObject
    {
    	private string _name;
    	public string name 
    	{ 
    		get { return this._name; } 
    		set
    		{
    			this._name = value.trim( new char[]{ '$' } )
    		}
    	}
    	
    	private string _raw;
    	public string raw 
    	{ 
    		get { return this._raw; }  
    		set { this._raw = value; }
    	}
    }
    
    class form1 : Form
    {
    	private List<FolderObject> _folders;
    	private BindingSource _bindingSource;
    
    	public form1()
    	{
    		Initialize();
    	}
    	
    	public void Initialize()
    	{
    		_folders = new List<FolderObject>();
    		_bindingSource = new BindingSource();
    		
    		List<FolderObject> folders = new List<FolderObject>();
    		//Fill folders ...
    		
    		_bindingSource.DataSource = folders;
    
    		//bind collection to listbox
    		listbox1.DisplayMember = "Name";
    		listbox1.ValueMember = "Raw";
    		listbox1.DataSource = _bindingSource;
    	}
    	
    	button1_Click(object sender, System.EventArgs e)
    	{
    		Console.WriteLine(string.format("Folder name is: {0}, Raw name is: {1}", listbox1.SelectedMember, listbox1.SelectedValue));
    	}
    }
