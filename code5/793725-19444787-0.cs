    public class WhateverYouWantLastPagePersister
    {
        private const string LastPageID = "LastPage";
        public string GetLastPage()
        {
            string lastPage = string.Empty;
            IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>(LastPageID, out lastPage);
            return lastPage;
        }
        public void PersistLastPage(string lastPage)
        {
            IsolatedStorageSettings.ApplicationSettings[LastPageID] = lastPage;
        }
    }
