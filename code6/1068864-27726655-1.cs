    List<string> values = new List<string>();
    foreach (Feature f in allFeatures)
    {
        var columnValues = f.ColumnValues;
        var firstLayerCode = columnValues[layercode].ToString();
        var secondLayerCode = columnValues[layercode2].ToString();
        if (columnValues.ContainsKey(layercode) && columnValues.ContainsKey(layercode2))
        {
            if (!values.Contains(firstLayerCode) && !values.Contains(secondLayerCode))
            {
                var combinedValue = firstLayerCode + ";" + secondLayerCode;
                values.Add(combinedValue);
            }
        }
    }
