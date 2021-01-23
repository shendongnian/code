    private void clbScenario_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index >= 0 && e.Index <= 4)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp1);
            else HideTabPage(tp1);
        }        
        else if (e.Index == 5 || e.Index == 8)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp2);
            else HideTabPage(tp2);
        }        
        else if (e.Index == 6)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp3);
            HideTabPage(tp3);
        }        
            
        else if (e.Index == 7)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp4);
            else HideTabPage(tp4);
        }
    }
