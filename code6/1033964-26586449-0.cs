    // Get the selected text from the ListBox.
    string name = ControlBox1.GetItemText(ControlBox1.SelectedItem);
    
    // Find the control that matches that Name. Assumes there is only ever 1 single match.
    Control control = ProjectPanel.Controls.Find(name, true).FirstOrDefault();
    
    // Set properties of the Control.
    control.Name = "new name";
    
    // If you know it's a Label, you can cast to Label and use Label specific properties.
    Label label = control as Label;
    label.Text = "some new text";
