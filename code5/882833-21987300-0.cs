	protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
	{
		base.OnCellEndEdit(e);
		// Force validation after each cell edit, making sure that 
		// all row changes are validated in the DataSource immediately.
		this.OnValidating(new System.ComponentModel.CancelEventArgs());
	}
