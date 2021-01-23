    var properties = _modelType.GetProperties(); // Or whatever... remove indexers etc
    foreach (object item in _dataSet)
    {
        foreach (var property in properties)
        {
            var value = property.GetValue(item, null);
            // Use the value somehow
        }
    }
