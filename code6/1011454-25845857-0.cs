    void ShowView<T>(ViewModelBase viewModel)
        where T : ViewBase
    {
        T view = new T();
        view.DataContext = viewModel;
        view.Show(); // or something similar
    }
