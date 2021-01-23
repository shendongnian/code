    int NumberOfDiv = Convert.ToInt32(TextBox_UserEntry.Text);
    for (int i = 0; i < NumberOfDiv; i++)
    {
    	Panel pnl = new Panel();
    	pnl.ID = "pnl" + Convert.ToInt32(i + 1);
    	ParentPanel.Controls.Add(pnl);
    }
