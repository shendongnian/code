    //Code added in form load.
    MyGrid1.KeepCursorColumnIndex = 2; //I want to keep focus on column index 2
    //MyGrid custom grid class 
    public partial class MyGrid : DataGridView
    {
    	private int _freezCursorColumnIndex = -1;
    	public int KeepCursorColumnIndex
    	{
    		get
    		{
    			return _freezCursorColumnIndex;
    		}
    		set
    		{
    			_freezCursorColumnIndex = value;
    		}
    	}
    
    	public MyGrid()
    	{
    		InitializeComponent();
    	}
    	protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    	{
    
    		if (_freezCursorColumnIndex > -1 && this.CurrentRow != null && keyData == Keys.Return)
    		{
    			this.CurrentCell = this.CurrentRow.Cells[KeepCursorColumnIndex];
    			keyData = Keys.None;
    		}
    
    		return base.ProcessCmdKey(ref msg, keyData);
    	}
    
    }
