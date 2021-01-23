    foreach (var checkListItem in ViewModel.CheckLists)
    {
        var item = new CheckboxElement(checkListItem.Caption);
        set.Bind(item).For(v => v.Value).To(vm => vm.IsChecked).TwoWay();
        section.Add(item);
    }
