        private static string GetPath(Folder f, List<Folder> table)
        {
            if (f.IdParent == 0)
            {
                return f.Name;
            }
            else
            {
                var parent = table.Find(d => d.Id == f.IdParent);
                return GetPath(parent, table) + "\\" + f.Name;
            }
        }
