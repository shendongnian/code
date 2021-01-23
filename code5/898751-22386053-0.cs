    private void ShowContent(Control content)
    {
        placeHolderPanel.Controls.Clear(); // clear current content
        placeHolderPanel.Controls.Add(content); // add new
        content.Dock = DockStyle.Fill; // fill placeholder area
    }
