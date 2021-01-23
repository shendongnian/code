    public class BasePage : PhoneApplicationPage
    {
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                WhateverYouWantLastPagePersister.PersistLastPage(CustomMethodToExtractPageNameFromUri(e.Uri));
            }
    }
