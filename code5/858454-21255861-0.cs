    public class TemplateSelector : DataTemplateSelector
        {
            public DataTemplate DataTemplate1 { get; set; }
    
            public DataTemplate SelectedDataTemplate { get; set; }
    
    
    
            protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
            {
                if (item.IsSelected)
                {
                   return SelectedDataTemplate;
                }
                else
                {
                   return DataTemplate1;
                }
                return base.SelectTemplateCore(item, container);
            }
        }
