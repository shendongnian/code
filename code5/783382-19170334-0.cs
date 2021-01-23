    public void HandleEvent(AdminTabStripCreated eventMessage)
    {        
        if (eventMessage.TabStripName == "product-edit")
        {
            var controller = new MyPluginController();
            var html = controller.GetHtmlToDisplayInTheTab();
            eventMessage.ItemFactory.Add().Text("My new tab").Content(html);
        }
    }
