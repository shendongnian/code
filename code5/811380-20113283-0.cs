     private static bool isAlreadyInstantiated()
        {
            new Mutex(true, "my_app", out mutex_bool);
            return !mutex_bool;
        }
        
        private static void getSelectedFiles()
        {
            selected_files = new List<SelectedFile>();
            
            String filename;
            // Required ref: SHDocVw (Microsoft Internet Controls COM Object)
            ShellWindows shell = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer window in shell)
            {
                filename = Path.GetFileNameWithoutExtension(window.FullName).ToLower();
                if (filename.ToLowerInvariant() == "explorer")
                {
                    Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
                    if (selected_files.Count == 0)
                    {
                        foreach (Shell32.FolderItem item in items)
                        {
                            if (active_folder == Path.GetDirectoryName(item.Path))
                                selected_files.Add(new SelectedFile("\"" + item.Path + "\"", item.Name, Math.Round(((double)item.Size / (double)1024), 2)));
                            else
                                break;
                        }
                    }
                    else
                        return;
                }
            }
        }
