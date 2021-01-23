    You can Try this way
    
    
        string values = "";
        foreach (SelectedListItem v in this.Multi1.SelectedItems)
        {
        values += v.Value + " " + v.Text + "</br>";
        }
        X.Msg.Alert("Selected", values).Show();
    
