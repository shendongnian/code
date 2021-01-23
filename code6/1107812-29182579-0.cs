        Outlook.Items _items;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.Folder inbox = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox) as Outlook.Folder;
            _items = inbox.Items;
            _items.ItemAdd += items_ItemAdd;
        }
        private void items_ItemAdd(object Item)
        {
            if (Item is Outlook.TaskRequestAcceptItem)
            {
                Outlook.TaskItem task = (Item as Outlook.TaskRequestItem).GetAssociatedTask(false);
                // some code here
            }
        }
