        private void ScanAllMailItems()
        {
            var theRootFolder = (Outlook.Folder)_outlookNameSpace.DefaultStore.GetRootFolder();
            RecurseThroughFolders(theRootFolder, 0);
        }
        private void RecurseThroughFolders(Outlook.Folder theRootFolder, int depth)
        {
            if (theRootFolder.DefaultItemType != Outlook.OlItemType.olMailItem)
                return;
            foreach (object item in theRootFolder.Items)
            {
                var mailItem = item as Outlook.MailItem;
                if (mailItem != null)
                {
                    var mi = mailItem;
                    ScanMailBody(mi);
                }
            }
            foreach (Outlook.Folder folder in theRootFolder.Folders)
            {
                RecurseThroughFolders(folder, depth + 1);
            }
        }
