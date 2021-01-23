    public partial class TopMenuViewModel 
    {
        public TopMenuViewModel()
        {
            TopMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Title = "File",
                    PageName =typeof(OfficeListView).FullName,
                    ChildMenuItems= {
                        new MenuItem
                        {
                            Title = "New"
                        },
                         new MenuItem
                        {
                            Title = "Open"
                        },
                         new MenuItem
                        {
                            Title = "Save"
                        }
                    }
                },
                new MenuItem
                {
                    Title = "Edit"
                },
                new MenuItem
                {
                    Title = "Search"
                }
            };
        }
