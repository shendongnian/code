    public ICommand OnListItemTapped
    {
        get
        {
            return new Command<Notification>(item =>
            {
                Debug.WriteLine(item.Title + " Cliked!");
            });
        }
    }
