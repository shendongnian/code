    bool first = true;
    Foreach (file in files)
    {
        if(first)
        {
            workflowProperties.Item["Title"] = file;
            workflowProperties.Item.Update();
            first = false;
        }
        else
        {
            var newItem = list.Items.Add();
            newItem["Title"] = file;
    	EventFiring eventFiring = new EventFiring();
    	eventFiring.DisableHandleEventFiring();
            newItem.Update();
    	eventFiring.EnableHandleEventFiring();
        }
    
    }
