    private void NewTab (string name, SteamID id)
    {
        var userControl = new ChatPage (name, id);
        TabPage newTab = new TabPage(name);
        newTab.Controls.Add(userControl);
        tabControl1.TabPages.Add(newTab);
    }
