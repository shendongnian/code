        var list = new List<List<string>>
        {
            new List<string> {"Test", "Test", "Test"},
            new List<string> {"Test", "Test", ""},
            new List<string> {"Test", "Test", "Test", "Test"}
        };
        var maxLength = list.Max(c => c.Max(r => r.Length));
        for (int i = 0; i < maxLength; i++)
        {
            ResulDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Field" + i, Binding = new Binding("Row" + i) });
        }
        foreach (var listItem in list)
        {
            var properties = new Dictionary<string, object>();
            for (int i = 0; i < listItem.Count; i++)
            {
                properties.Add("Row" + i, listItem[i]);
            }
            var myObject = GetDynamicObject(properties);
            ResulDataGrid.Items.Add(myObject);
        }
    public static dynamic GetDynamicObject(Dictionary<string, object> properties)
            {
                var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
                foreach (var property in properties)
                {
                    dynamicObject.Add(property.Key, property.Value);
                }
                return dynamicObject;
            }
