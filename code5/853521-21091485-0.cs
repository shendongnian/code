        public void SetAllFilesAsReadOnly(string rootPath)
        {
            foreach (string file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                var attr = File.GetAttributes(file);
                // set read-only
                attr = attr | FileAttributes.ReadOnly;
                File.SetAttributes(file,attr);
            }
        }
