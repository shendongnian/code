    private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string searchTerm;
        using (var searchForm = new SearchForm())  // used 'using' to dispose the form
        {
            searchForm.ShowDialog();
            searchTerm = searchForm.SearchTerm;
        }
        // do something with searchTerm
    }
