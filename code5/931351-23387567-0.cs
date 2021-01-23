    class MyRow : DataGridViewRow
    {
    
    	public bool IsChild { get; set; }
    
    	public override object Clone()
    	{
    		var clonedRow = base.Clone() as MyRow;
    		clonedRow.IsChild = this.IsChild;
    		return clonedRow;
    	}
    }
