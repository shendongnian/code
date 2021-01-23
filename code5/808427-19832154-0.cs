	private void CancelCopyCommand(object sender, DataObjectEventArgs e)
	{
		MessageBox.Show("Copy not allowed !");
		e.CancelCommand();
	}
