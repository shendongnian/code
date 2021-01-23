    private void Apply(List<List<string>> list, Action<string[]> method)
    {
        foreach (var items in list)
        {
            for (int valuesIndex = 1; valuesIndex < items.Count - 1; valuesIndex++)
            {
                var key = items[valuesIndex];
                string values;
                if (dict.TryGetValue(key, out values))
                {
                    method(SplitValues(values));
                }
                else
                {
                    //Throw Exception
                }
            }
        }
    }
    Apply(stepObj.GetClosedShells(), stepObj.SetCsAdvFace);
    Apply(stepObj.GetOpenShells(), stepObj.SetOsAdvFace);
    ...
