    public string GetStringValueFromData(DataTable data, Func<DataRow, object> expression)
    {
        switch (this.MethodType)
        {
            case (LabelMethodType.Count):
                return data.AsEnumerable().Select(expression).Count().ToString();
            case (LabelMethodType.Sum):
                return data.AsEnumerable().Select(expression).Cast<int>().Sum().ToString();
            case (LabelMethodType.Average):
                return data.AsEnumerable().Select(expression).Cast<int>().Average().ToString();
        }
    
        return string.Empty;
    }
