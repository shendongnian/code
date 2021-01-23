    private void buttonX_Click(object sender, EventArgs e)
    {
        // This is represents the distance between the bottom 
        // of one control to the top of the next control
        // Normally it would be defined globally, and used when you
        // lay out your controls.
        const int controlPadding = 6;
        var xButton = sender as Button;
        if (xButton == null) return;
        var minTopValue = xButton.Bottom;
        var distanceToMoveUp = xButton.Height + controlPadding;
        // Find all controls that have the Tag and are at the same height as the button
        var controlsToDelete = Controls.Cast<Control>().Where(control =>
            control.Tag != null &&
            control.Tag.ToString() == "dynamic" &&
            control.Top == xButton.Top)
            .ToList();
        // Delete the controls
        controlsToDelete.ForEach(Controls.Remove);
        // Get all controls with the same tag that are below the deleted controls
        var controlsToMove = Controls.Cast<Control>().Where(control =>
            control.Tag != null &&
            control.Tag.ToString() == "dynamic" &&
            control.Top > minTopValue);
        // Move each control up the specified amount
        foreach (var controlToMove in controlsToMove)
        {
            controlToMove.Top -= distanceToMoveUp;
        }
    }
