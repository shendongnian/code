    private IEnumerable<Filter> GetChildrenChecked(IEnumerable<Filter> filters, IEnumerable<FilterViewModel> visibleList)
    {
        List<Filter> returnValue = new List<Filter>();
        foreach (var filter in filters)
        {
            foreach (var filterVM in visibleList
                .Where(filterVM => filter.ID == filterVM.ID))
            {
               if (filter.Children.Any())
                {
                    returnValue.AddRange(GetChildrenChecked(filter.Children, filterVM.Children));
                }
                else
                {
                    if (filterVM.IsChecked)
                     returnValue.Add(filter);
                }
            }
        }
        return returnValue;
    }
