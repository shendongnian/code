    public ObservableCollection ObjectList {...}
    public static readonly DependencyProperty ObjectListProperty =
        DependencyProperty.Register(...OnObjectListChanged...);
    private static void OnObjectListChanged(...)
    {ObjectList.CollectionChanged += OnObjectListCollectionChanged;}
    private void OnObjectListCollectionChanged(...){ UpdateVisualStates(); }
    private void UpdateVisualStates()
    {
        //actually you have to instatiate a SolidColorBrush here
        if (ContainsAtLeastOneAnimal()) { m_border.Background = Colors.Red; }
        else if (ContainsAtLeastOneVegetable()) {m_border.Background = Colors.Green;}
        else { m_border.Background = Colors.Blue; }
    }
