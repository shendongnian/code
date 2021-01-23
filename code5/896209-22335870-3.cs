    Parent parent = //however you are getting the parent
    if (!parent.Children.Any(n => n.DisplayName == newNode.DisplayName))
    {
       parent.Children.Add(newNode)
       parent.Children = new ObservableCollection<ViewModel>(parent.Children.OrderBy(n => n.DisplayName));
       //OR,
       parent.Children.InsertItem(parent.Children.IndexOf(parent.Children.OrderBy(n => n.DisplayName).Last(n => n.DisplayName < newNode.DisplayName)), newNode);
    }
