    foreach (var line in lines)
    {
        // Create a new CheckBox
        var checkBox = new CheckBox();
        // Set its properties
        checkBox.Text = line;
        ...
        // Add it to the form's collection of controls
        this.Controls.Add(checkBox);
        // Adjust checkBox.Location depending on where you want it
        checkBox.Location = new Point(0, 0);
    }
