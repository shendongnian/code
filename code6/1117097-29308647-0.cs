     public static string GetExtendedFileAttribute(string filePath, string propertyName)
        {
            string retValue = null;
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
            object shell = Activator.CreateInstance(shellAppType);
            Shell32.Folder folder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { @"C:\Windows\System32" });
            int? foundIdx = null;
            for (int i = 0; i < short.MaxValue; i++)
            {
                string header = folder.GetDetailsOf(null, i);
                if (header == propertyName)
                {
                    foundIdx = i;
                    break;
                }
            }
            if (foundIdx.HasValue)
            {
                foreach (FolderItem2 item in folder.Items())
                {
                    if (item.Name.ToUpper() == System.IO.Path.GetFileName(filePath).ToUpper())
                    {
                        retValue = folder.GetDetailsOf(item, foundIdx.GetValueOrDefault());
                        break;
                    }
                }
            }
            return retValue;
        }
