    private static EditSettings winEditSettings = null;
    public static void WakeUp()
    {
        if (winEditSettings == null)
        {
            winEditSettings = new EditSettings();
        }
        winEditSettings.Activate();  // This may need to be inside the block above
        winEditSettings.Show();
    }
