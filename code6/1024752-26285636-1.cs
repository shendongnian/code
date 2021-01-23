    private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string searchTerm;
        using (var searchForm = new SearchForm())  // used 'using' to dispose the form
        {
            AboutBox.ShowDialog();
            searchTerm = AboutBox.SearchTerm;
        }
        // do something with the search term
    }
