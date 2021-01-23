     void findMyCalendar(String name)
        {
            string path = null;
    
            Outlook.Application app = new Outlook.Application();
            Outlook.NameSpace ns = app.GetNamespace("MAPI");
            //  there may be more than one Store
            //  each .ost and .pst file is a Store
            Outlook.Folders folders = ns.Folders;
    
            foreach (Outlook.Folder folder in folders)
            {
                Outlook.MAPIFolder root = folder;
                path = findCalendar(root, name);
    
                if (path != null)
                {
                    break;
                }
            }
    
            MessageBox.Show(path ?? "not found!");
        }
    
    //  non-recursive search for just one level
    public string findCalendar(MAPIFolder root, string name)
        {
            string path = null;
    
            foreach (Outlook.MAPIFolder folder in root.Folders) 
            {
                if (folder.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) &&
                    (folder.DefaultItemType == OlItemType.olAppointmentItem))
                {
                    path = folder.FolderPath;
                    break;
                }
            }
    
            return path;
        } 
