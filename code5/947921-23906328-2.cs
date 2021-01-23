    class ProductSelector : UserControl
    {
        ... //add controls to user control
        public event EventHandler CategoryChanged;
        public event EventHandler ProductChanged;
        ...
        public void PopulateCategories(list<string> names, list<string> ids)
        {
            ...
        }
        public void PopulateProducts(list<string> names, list<string ids)
        {
            ...
        }
    }
    
