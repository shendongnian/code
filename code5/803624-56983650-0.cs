    var res = dbContext.Model.FindEntityType(typeof(TableName))
                               .GetProperties().Select(x => x.Relational().ColumnName)
                               .ToList();
    var index = 0;    
    var propertyInfo = res[index].PropertyInfo;
    var columnName = res[index].Relational().ColumnName;
    var propertyName = propertyInfo.Name;
    var propertyValue = propertyInfo.GetValue(sourceObject); // NEED OBJECT TO GET VALUE
