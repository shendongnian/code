  	var dataTable = new DataTable(typeof(TEntity).Name);
	var navProperties = GetNavigationProperties<TEntity>(ctx);
	
	var props = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
	
	//Add props to datatable
	foreach (var prop in props.Except(navProperties))
	    dataTable.Columns.Add(prop.Name);
