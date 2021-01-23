    var dataSet = new DataSet();
    var dataTable = dataSet.Tables.Add();
    dataTable.Columns.Add("from");
    dataTable.Columns.Add("cityId");
    dataTable.Columns.Add("cityName");
    dataTable.Columns.Add("cityCode");
    // foreach KeyValuePair in IDictionary<TKey, ICollection<TValue>>
    foreach (var cityGroup in cities)
    {
        // foreach TValue in ICollection<TValue>
        foreach (var city in cityGroup.Value)
        {
            dataTable.LoadDataRow(
                new object[]
                {
                    cityGroup.Key,
                    city.cityId,
                    city.cityName,
                    city.cityCode
                },
                LoadOption.PreserveChanges);
        }
    }
