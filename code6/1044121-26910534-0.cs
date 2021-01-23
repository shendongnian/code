    //Check trial state and set PivotItem
        if ((Application.Current as App).IsTrial)
        {
            PivotControl.Items.Remove(PivotControl.Items.Single(p => ((PivotItem)p).Name == "Name_PivotItem"));
        }
        else
        {
            PivotControl.Items.Add(PivotControl.Items.Single(p => ((PivotItem)p).Name == "Name_PivotItem"));
        }
