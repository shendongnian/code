    List<TabPage> tabPages = new List<TabPage>(); // Creates a list of tabPage items
    for(int x = 0; x < 10; x++) // A loop to create 10 tab pages
    {
        // The variable name "tabPage" is for internal code use.
        // The variable name is one used in the scope of one loop.
        TabPage tabPage = new TabPage();
        // Setting the tabPage.Name property is how you give a name to this object
        // Here the Name of the tab will be "tab0" through to "tab9" 
        tabPage.Name = "tab" + x;
        tabPages.Add(tabPage); // Add the current tabPage to the list
    }
    // Now that we have a list of TabPage Items we can search the list
    foreach(TabPage tab in tabPages)
    {
        if(tab.Name.Equals("tab5"))
        {
            System.Diagnostics.Debug.WriteLine("Tab 5 was found");
        }
    }
