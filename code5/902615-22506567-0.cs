    public void Main()
    {
        var jsonObject = Json.Decode(FB); // FB is your JSON string.
        var values = new List<string>();
        FindValues(jsonObject);
    }
    public void FindValues(jsonObject, values)
    {
        foreach (var child in jsonObject)
        {
              if (child.key == 'value')
              {
                   values.Add(child.value);
              }
              // Recursively call FindValues on child objects.
              FindValues(child, values);
        }
    }
