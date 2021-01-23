    Priority p = Priority.High; // Assign literal
    MessageBox.Show(p.ToString()); // High
    MessageBox.Show(Priorities.GetCode(p).ToString()); // H
    Priority p = Priorities.GetPriority('L'); // Cast from character
    MessageBox.Show(p.ToString()); // Low
    MessageBox.Show(Priorities.GetCode(p).ToString()); // L
    Priority p; // Safe assigning
    if (!Priorities.TryGetPriority('M', out p))
        return;
    MessageBox.Show(p.ToString()); // Medium
    MessageBox.Show(Priorities.GetCode(p).ToString()); // M
