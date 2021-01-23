    string[] lines = File.ReadAllLines(Path.Combine(dataFolder, "Permissions.txt"));
    bool userExists = lines.Any(ln => ln == newName); // or any comparison you like
    
    // use the bool variable to set the visibility
    WidgetForm.Visible = userExists;
