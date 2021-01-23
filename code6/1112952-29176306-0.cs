    private bool IsTaskItemExists(Outlook.TaskItem oTaskItem)
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
    
                    for (int i = 1; i <= taskFolderItems.Count; i++)
                    {
                        task = taskFolderItems[i] as Outlook.TaskItem;
                        if (task != null && task.Subject.ToLower() == oTaskItem.Subject.ToLower())
                        {
                            
                            foundItem = true;
                            break;
                        }
                    }
    
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
