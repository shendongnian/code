    class item
    {
       ...
       List<item> childItems;
    
        public List<Folder> Folders
        {
            get
            {
                return childItems.OfType<Folder>();
            }
        }
    }
