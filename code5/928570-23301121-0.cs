    public class CompanyTemplateSelector : DataTemplateSelector
    {
        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var containingItem = container as GridViewItem;
            
            if (item is UserDetails)
            {
                UserDetails detail = (UserDetails)item;
                if (detail.UserId == -1) 
                {
                    containingItem.IsEnabled = false;
                    return Empty;
                }
                else
                {
                    containingItem.IsEnabled = true;
                    return DataPresent;
                }
            }
            return DataPresent;
        }
        public DataTemplate DataPresent
        {
            get;
            set; 
        }
        public DataTemplate Empty
        {
            get;
            set; 
        }
    }
