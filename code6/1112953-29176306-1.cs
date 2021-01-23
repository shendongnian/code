       private bool IsTaskItemExists(TaskObject oTaskItem)
                {
                    Outlook.NameSpace ns = null;
                    Outlook.MAPIFolder tasksFolder = null;
                    Outlook.Items taskFolderItems = null;
                    Outlook.TaskItem task = null;
                    Outlook.Application outlookApp = new Application();
                    bool foundItem = false;
                    try
                    {
                        ns = outlookApp.Session;
                        tasksFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks);
                        taskFolderItems = tasksFolder.Items;
    
                        foundItem = (taskFolderItems.Find(String.Format("[Property Name]='{0}'", oTaskItem.Property) ) != null);
                        
           
                        return foundItem;
                        
                    }
                    finally
                    {
                        if (taskFolderItems != null)
                            Marshal.ReleaseComObject(taskFolderItems);
                        if (tasksFolder != null)
                            Marshal.ReleaseComObject(tasksFolder);
                        if (ns != null)
                            Marshal.ReleaseComObject(ns);
                    }
                }
