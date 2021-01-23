    private Collection GetAllBindingsInDatagrid(DataGrid dg)
    {
    	Collection bindings = new Collection();
    	if (dg.ItemsSource != null) {
    		foreach (object item in dg.ItemsSource) {
    			DataGridRow row = dg.ItemContainerGenerator.ContainerFromItem(item);
    			if (row != null) {
    				foreach (BindingExpression binding in row.BindingGroup.BindingExpressions) {
    					bindings.Add(binding);
    				}
    			}
    		}
    	}
    	return bindings;
    }
