    private void LoadPanels()
    {
        panel1.Location = new Point(10,10);
        panel2.Location = new Point(10,10);
        panel3.Location = new Point(10,10);
        panel4.Location = new Point(10,10);
        panel5.Location = new Point(10,10);
    
        panel1.Visible = true;
        panel2.Visible = false;
        panel3.Visible = false;
        panel4.Visible = false;
        panel5.Visible = false;
    }
    
    private void VisiblePanel(string panelName)
    {
        string[] panels = new string[]{"panel1","panel2","panel3","panel4","panel5"};
        for (int i=0;i<panels.Length;i++)
            this.Controls[panels[i]].Visible = (panels[i] == panelName);
        
        this.Controls[panelName].BringToFront(); //Not required you can remove this line.
    }
