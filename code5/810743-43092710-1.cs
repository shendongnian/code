    public class CheckBoxReadOnly : CheckBox
    {
    
    	private bool _ReadOnly = false;
    	[DefaultValue(false)]
    	public bool ReadOnly {
    		get { return _ReadOnly; }
    		set {
    			if (_ReadOnly != value) {
    				EventArgs e = new EventArgs();
    				_ReadOnly = value;
    				OnReadOnlyChanged(e);
    			}
    		}
    	}
    	protected void OnReadOnlyChanged(EventArgs e)
    	{
    		if (ReadOnlyChanged != null) {
    			ReadOnlyChanged(this, e);
    		}
    	}
    
    	public event  ReadOnlyChanged;
    
    	protected override void OnCheckedChanged(EventArgs e)
    	{
    		static Int16 flag;
    		if (ReadOnly) {
    			flag += 1;
    			if (flag == 1)
    				Checked = !Checked;
    		} else {
    			base.OnCheckedChanged(e);
    		}
    		flag = 0;
    	}
    
    }
