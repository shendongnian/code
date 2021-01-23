    private T GetItemsPanel<T>(ItemsControl itemsControl) where T : Panel
        {
            T _Panel = UIHelper.FindVisualChild<T>(itemsControl);
            if (_Panel == null)
            {
                ItemsPresenter itemsPresenter = UIHelper.FindVisualChild<ItemsPresenter>(itemsControl);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                    _Panel = VisualTreeHelper.GetChild(itemsPresenter, 0) as T;
                }
            }
            return _Panel;
        }  
