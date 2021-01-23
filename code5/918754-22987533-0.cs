    public void change()
    {
        for (int i =0;i<10 ;i++)
        {
            c.Add(new TokenList("hello", "Hi"));
        }
        longlistselector.ItemsSource.Clear();
        longlistselector.ItemsSource = c;
    }
