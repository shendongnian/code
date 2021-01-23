    class YourClass
    {
        private Searcher srch;
        void YourMethod()
        {
            if (btnSearch.Text == "Search")
            {
                srch = new Searcher();
                srch.Search();
                btnSearch.Text = "Cancel";
                return;
            }
            if (btnSearch.Text == "Cancel")
            {
                srch.Cancel();
            }
        }
    }
