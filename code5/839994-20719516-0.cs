    public static readonly DependencyProperty RepositoryProperty =
            DependencyProperty.Register("Repository",
                                        typeof(ICarRepository),
                                        typeof(MainControl),
                                        new PropertyMetadata(OnRepositoryChanged));
    private static void OnRepositoryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ICarRepository repository = e.NewValue as ICarRepository;
        ((MainControl)d).DataContext = repository;
    }
