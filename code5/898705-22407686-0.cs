    private void UpdateView(object sender, EventArgs e)
    {
        DataContext = (BaseViewModel)sender;
        ((BaseViewModel)DataContext).OnViewModelChange += UpdateView;
    }
