        public List<item> FileSystemItems
        {
            get
            {
                var list = new List<item>();
                foreach (child in childItems)
                {
                    if (child is IFile || child is IFolder)
                        list.Add(child);
                }
                return list;
            }
        }
