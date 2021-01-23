    Dictionary<string,string> values = new Dictionary<string,string> ();
    //...
    if (!values.ContainsKey(f.ColumnValues[layercode].ToString()) && !values.ContainsValue(f.ColumnValues[layercode2].ToString()))
    {
        values[f.ColumnValues[layercode].ToString()] = f.ColumnValues[layercode2].ToString();
    }
