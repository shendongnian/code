    if (!SetupManagerSettings.BootStrapperLocation.IsFile()) // Just another extension method to check if its a file
    {
        settingsToolStripMenuItem.Checked = true;  // Event handler OnChecked ensures the settings panel is unhidden
        settingsPropertyGrid.ActivateControl();
        settingsPropertyGrid.SelectPropertyGridItemByName("BootStrapperLocation"); // Here is the extension method 
        return false;
    }
