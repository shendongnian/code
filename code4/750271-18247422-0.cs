    private void NewsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        NLBI = (NewsListBoxItem)NewsListBox.SelectedItem;
        Predicate <HPArticle> articleFinder = (HPArticle p) => { return p.Id == int.Parse(NLBI.id.Text); };
        (App.Current as App).ToArticlePage = NewsList.Result.Articles.Find(articleFinder);
    }
