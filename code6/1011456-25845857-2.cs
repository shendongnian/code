    void ShowView<T>(ViewModelBase viewModel)
        where T : ViewBase, new()
    {
        T view = new T();
        view.DataContext = viewModel;
        view.Show(); // or something similar
    }
