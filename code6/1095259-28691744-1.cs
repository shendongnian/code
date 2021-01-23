    foreach (var _globalListTable in query)
	{
		foreach (var _productTable in _globalListTable.ProductGroupTable.ProductTables)
		{
			var _exclude = _productTable.ComponentTables.Where(i => i.ComponentTypeId != componentTypeId);
			_productTable.ComponentTables = _productTable.ComponentTables.Except(_exclude).ToList();
		}
	}
	return query;
