    Priority p = Priority.High; // Assign literal
    MessageBox.Show(p.ToString()); // H
    Priority p = (Priority)'L'; // Cast from character
    MessageBox.Show(p.ToString()); // L
    
    Priority p; // Safe assigning
    if (!Priority.TryGetPriority('M', out p))
        return; // Handle invalid scenario
    MessageBox.Show(p.ToString()); // M
