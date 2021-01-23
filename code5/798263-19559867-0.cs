    protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
	{
		base.OnPreviewKeyDown(e);
		if (e.Key == System.Windows.Input.Key.Space)
		{
			//Prevent spaces (space does not "raise" OnPreviewTextInput)
			e.Handled = true;
		}
	}
