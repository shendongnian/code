    List<string> values = new List<string>();
    foreach (Feature f in allFeatures)
    {
        if (f.ColumnValues.ContainsKey(layercode)&& f.ColumnValues.ContainsKey(layercode2))
        {
            if (!values.Contains(f.ColumnValues[layercode].ToString()) && !values.Contains(f.ColumnValues[layercode2].ToString()))
            {
                var first = f.ColumnValues[layercode].ToString();
                var second = f.ColumnValues[layercode2].ToString();
                var combinedValue = first + ";" + second;
                values.Add(combinedValue);
            }
        }
    }
