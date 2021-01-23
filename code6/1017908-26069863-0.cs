       public class ObservableListSource<T> : ObservableCollection<T>, IListSource
            where T : class
        {
            private IBindingList _bindingList;
    
            bool IListSource.ContainsListCollection { get { return false; } }
    
            IList IListSource.GetList()
            {
                return _bindingList ?? (_bindingList = this.ToBindingList());
            }
        } 
    this.categoryBindingSource.DataSource =
                    _context.Categories.Local.ToBindingList();
