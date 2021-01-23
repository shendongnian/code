    foreach(var rx in rxs)
    {
        var viewModel = new StringByColumnViewModel(stuff);
        // You could use either IObserver<T> or standard .NET events here
        // I'm using IObserver<T> because you can use interesting libraries
        // with it (namely Reactive Extensions) but both uses are valid
        viewModel.Edited.Subscribe(stringByColViewModel => OnHandleEdit(stringByColViewModel));
        Strings.Add(viewModel);
    }
    protected void OnHandleEdit(StringByColViewModel stringByColViewModel)
    {
        var position = Strings.IndexOf(stringByColViewModel);
        Strings.RemoveAt(position);
        Strings.Insert(position, stringByColViewModel);
    }
