    public override string ToString()
    {
        Dictionary<string, string> fieldValues = new Dictionary<string, string>();
        var fields = this.GetType().GetFields();
        foreach (var field in fields)
        {
            fieldValues[field.Name] = field.GetValue(this).ToString();
        }
        return string.Join(", ", fieldValues.Select(x => string.Format("{0}: {1}", x.Key, x.Value)));
    }
