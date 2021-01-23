    private void clbScenario_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.index >= 0 && e.index <= 4)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp1);
            else HideTabPage(tp1);
        }        
        else if (e.index == 5 || e.index == 8)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp2);
            else HideTabPage(tp2);
        }        
        else if (e.index == 6)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp3);
            HideTabPage(tp3);
        }        
            
        else if (e.index == 7)
        {
            if (e.CurrentValue.ToString() == "Unchecked") tabControl1.TabPages.Add(tp4);
            else HideTabPage(tp4);
        }
    }
