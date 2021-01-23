        private ObservableCollection<ICDDocumentItemViewModel> GetFiltered(string filter)
        {
            ObservableCollection<ICDDocumentItemViewModel> filteredCollection;
            if (filter.Length > 3)
            {
                filteredCollection = new ObservableCollection<ICDDocumentItemViewModel>(_linearCollection.Where(x => x.Name.ToLower().Contains(filter)));
                filteredCollection.ToList().ForEach(DetectChildren);
            }
            else
            {
                filteredCollection = new ObservableCollection<ICDDocumentItemViewModel>();
            }
            return filteredCollection;
        }
        private void DetectChildren(ICDDocumentItemViewModel item)
        {
            item.IsExpanded = item.Children.Any();
        }
