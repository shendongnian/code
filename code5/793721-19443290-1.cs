    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            switch (pageType)
            {
                case PageType.NONE:
                    //Your code
                    break;
                case PageType.PAGE_1:
                    //Your code
                    break;
                case PageType.PAGE_2:
                    //Your code
                    break;
                case PageType.PAGE_3:
                    //Your code
                    break;
                case PageType.PAGE_4:
                    //Your code
                    break;
            }
        }
    }
