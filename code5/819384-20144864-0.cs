        public class ComboBoxSelectionTemplateSelector : DataTemplateSelector 
        {
            public DataTemplate TextTemplate 
            {
                get;
                set;
            }
            public DataTemplate ContentTemplate 
            {
                get;
                set;
            }
    
            public override System.Windows.DataTemplate SelectTemplate(object item, DependencyObject container) 
            {
                if (item is string)
                    return TextTemplate;
                else
                    return ContentTemplate;
            }
        }
