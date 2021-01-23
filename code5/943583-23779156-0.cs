    for (int i = 0; i < Portals.Count; i++)
    {
        try
        {
            if (!Portal[i].IsConnected)
            {
                Portal[i].Connect();
                ///..Permorm variours actioms...
            }
        }
        catch 
        {
            Window7 win = new Window7();
            win.label1.Content = "Connect to Portal " + (i + 1).ToString() + " Failed..";
            win.ShowDialog();
        }
        // TODO - Some more code here
    }
