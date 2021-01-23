    private static void SetupAxis(Axis axis)
    {
        // Set the logarithmic scale mode:
        axis.IsLogarithmic = true;
        // Enable the minor grid lines:
        axis.MinorGrid.Enabled = true;
        // Set the color of the minor grid lines:
        axis.MinorGrid.LineColor = Color.Gray;
        // Set the inverval to 1:
        axis.MinorGrid.Interval = 1;
        // Enable the major grid lines:
        axis.MajorGrid.Enabled = true;
        // If not set, the major grid lines are defaulted to the black color
    }
