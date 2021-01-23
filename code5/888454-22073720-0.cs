    private void Selection(object sender, SelectionChangedEventArgs e)
    {
	    if(DateAutoCompleteBox == null)
     	{
	        MessageBox.Show("DateAutoCompleteBox   is null"); return;
	    }
		if(Pf == null)
	    {
	        MessageBox.Show("Pf  is null"); return;
	    }
	    if(Pf.Text == null)
	    {
	        MessageBox.Show("Pf.Text  is null"); return;
	    }
        if (Findpf() == 12)
        {
            DateAutoCompleteBox.Visibility = System.Windows.Visibility.Collapsed;
        }
        else
        {
            DateAutoCompleteBox.Visibility = System.Windows.Visibility.Visible;
        }
    }
