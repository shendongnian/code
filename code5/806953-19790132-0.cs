    var fields = editmodel.GetType().GetFields();
    foreach (var item in fields)
    {
        if (item.GetValue(editmodel) == database.field)
        {
            // Update the value
            // Write a string about what changed
            // Add the string to the list of what changed
        }
     }
