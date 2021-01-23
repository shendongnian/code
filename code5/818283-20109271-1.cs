    class item
    {
       ...
       List<item> childItems;
    
        public IEnumerable<item> FileSystemItems
        {
            get
            {
                return childItems.Where(x => x is IFile || x is IFolder);
            }
        }
    }
