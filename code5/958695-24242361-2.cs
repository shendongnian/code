        private static string GetPath(Folder f)
        {
            if (f.IdParent == 0)
            {
                return f.Name;
            }
            else
            {
                var parent = tableData.Find(d => d.Id == f.IdParent);
                return GetPath(parent) + "|" + f.Name;
            }
        }
