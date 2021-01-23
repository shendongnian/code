    public static readonly DependencyProperty RepositoryProperty = DependencyProperty.Register("Repository", typeof(IRepository), typeof(UserControl2));
    public IRepository Repository
    {
        get { return (IRepository)GetValue(RepositoryProperty); }
        set { SetValue(RepositoryProperty, value); }
    }
