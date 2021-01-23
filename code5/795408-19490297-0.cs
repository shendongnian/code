         [WebBrowsable(true),
         WebDisplayName("Page Title"),
         WebDescription("Title displayed on the page"),
         Category("Test Properties"),
         Personalizable(PersonalizationScope.Shared)]
        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                _pageTitle = value;
            }
        }
