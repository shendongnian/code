    foreach (PropertyInfo property in mapping)
                {
    ...
    if (isInventoryReportBaseType && typeof(Dictionary<string, object>).IsAssignableFrom(property.PropertyType))
                    {
                        var dataSource = (ReportInventoryBase)Activator.CreateInstance(entityType, dbContext);
    
                        foreach (var item in dataSource.ColumnNameAndText)
                        {
                            var columnName = item.Key;
    
                            var newMap = new CsvPropertyMap(property);
                            newMap.Name(columnName);
                            newMap.TypeConverter(new InventoryEntryListSpecifiedTypeConverter(item.Key));
    
                            customMap.PropertyMaps.Add(newMap);
                        }
    ...
    }
