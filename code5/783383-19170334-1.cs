    public void HandleEvent(AdminTabStripCreated eventMessage)
    {        
        if (eventMessage.TabStripName == "product-edit")
        {
            eventMessage.ItemFactory.Add().Text("My new tab").Content("<b>Hello world!</b>");
        }
    }
