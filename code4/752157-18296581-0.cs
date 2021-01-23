    private void CaptureScreen()
    {
        memoryImage = new Bitmap(tabControlMain.SelectedTab.Width, tabControlMain.SelectedTab.Height);
        tabControlMain.SelectedTab.DrawToBitmap(memoryImage, tabControlMain.SelectedTab.ClientRectangle);
        tabControlMain.SelectedIndex = 1;
        memoryImage2 = new Bitmap(tabControlMain.SelectedTab.Width, tabControlMain.SelectedTab.Height);        
        tabControlMain.SelectedTab.DrawToBitmap(memoryImage2, tabControlMain.SelectedTab.ClientRectangle);
    }
