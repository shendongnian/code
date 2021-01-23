    foreach (file in files)
    {
        var property = file.GetType().GetProperty("v1");
        if (property == null)
        {
            // it doesn't have the property
        }
        else
        {
            // it has the property
            // read it:
            var v1 = property.GetValue(file, null);
            // write it:
            property.SetValue(file, v1, null);
        }
    }
