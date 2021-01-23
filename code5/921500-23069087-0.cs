    List<Panel> Panels;
    private void Initialization()
    {
        Panels = new List<Panel>();
        Panels.Add(pnl1);
        Panels.Add(pnl2);
        //add all your panels into collection
        
        foreach(Panel Item in this.Panels)
        {
            //add handle to panel on click event
            Item.Click += OnPanelClick;
        }
    }
    
    private void OnPanelClick(object sender, EventArgs e)
    {
        foreach(Panel Item in this.Panels)
        {
            //remove highlight from your panels, real property should have other name than Panel.HighlightEnabled
            Item.HighlightEnabled = false;
        }
        ((Panel)sender).HighlightEnabled = true; //add highlight to Panel which invoked Click event
        Application.DoEvents(); //ensure that graphics redraw is completed immediately
    }
    
    private void AddNewPanelIntoLocalCollection(Panel panel)
    {
        //here you can add new items to collection during program lifecycle
        panel.Click += OnPanelClick;
        this.Panels.Add(panel);
    }
