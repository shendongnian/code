    checkBox.ForeColor = Color.Gray; // Read-only appearance
    checkBox.AutoCheck = false;      // Read-only behavior
    // Tooltip is possible because the checkbox is Enabled
    var toolTip = new ToolTip();
    toolTip.SetToolTip(checkBox, "This checkbox is read-only.");
