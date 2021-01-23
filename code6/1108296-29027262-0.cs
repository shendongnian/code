            public SeleniumModel()
            {
                SelectedBrowser = "";
                BrowserList = new List<SelectListItem>();
                EnviormentList = new List<SelectListItem>();
            }
    
            public String SelectedBrowser
            {
                get;
                set;
            }
    
            public List<SelectListItem> BrowserList
            {
                get;
                set;
            }
    
            public List<SelectListItem> EnviormentList
            {
                get;
                set;
            }
