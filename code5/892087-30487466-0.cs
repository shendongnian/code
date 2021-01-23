    public class Mail
    {
        public MailItem mailItem { get; set; }
        public String path { get; set; }
    }
    public static class Mails
    {
        public static List<Mail> readPst(string pstFilePath, string pstName)
        {
            List<Mail> mail = new List<Mail>();
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            NameSpace outlookNs = app.GetNamespace("MAPI");
            // Add PST file (Outlook Data File) to Default Profile
            outlookNs.AddStore(pstFilePath + pstName);
            string storeInfo = null;
            foreach (Store store in outlookNs.Stores)
            {
                storeInfo = store.DisplayName;
                storeInfo = store.FilePath;
                storeInfo = store.StoreID;
            }
            MAPIFolder rootFolder = outlookNs.Stores[pstName.Substring(0,pstName.Length-4)].GetRootFolder();
            // Traverse through all folders in the PST file
            Folders subFolders = rootFolder.Folders;
            foreach (Folder folder in subFolders)
            {
                ExtractItems(mail, folder);
            }
            // Remove PST file from Default Profile
            outlookNs.RemoveStore(rootFolder);
            return mail;
        }
        private static void ExtractItems(List<Mail> mailItems, Folder folder)
        {
            Items items = folder.Items;
            int itemcount = items.Count;
            foreach (object item in items)
            {
                if (item is MailItem)
                {
                    MailItem mailItem = item as MailItem;
                    Mail mail = new Mail();
                    mail.mailItem = mailItem;
                    mail.path = folder.FolderPath + folder.Name;
                    mailItems.Add(mail);
                }
            }
            foreach (Folder subfolder in folder.Folders)
            {
                ExtractItems(mailItems, subfolder);
            }
        }
    }
