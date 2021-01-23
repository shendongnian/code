    // in ExpanderListViewModel
    foreach (var expanderViewModel in Expanders) {
        expanderViewModel.PropertyChanged += Expander_PropertyChanged;
    }
    ...
    private void Expander_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        var thisExpander = (ExpanderViewModel)sender;
        if (e.PropertyName == "IsSelected") {
            if (thisExpander.IsSelected) {
                foreach (var otherExpander in Expanders.Except(new[] {thisExpander})) {
                    otherExpander.IsSelected = false;
                }
            }
        }
    }
