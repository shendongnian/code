    var selectedItem = dgParametrs.SelectedItem as Row;
    if (selectedItem != null)
    {
    	if (_viewModel.ObjectViewNodel.RowInputColl != null)
    	{
    		if(_viewModel.ObjectViewModel.RowInputColl.Contains(selectedItem))
    			_viewModel.ObjectViewModel.RowInputColl.Remove(selectedItem); //after that RowInputColl is null!
    	}
    	else 
    	{
    		_viewModel.ObjectViewModel.RowInputColl = new ObservableCollection<Row>();
    	}
    }
     
