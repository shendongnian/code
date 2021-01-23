    public class MyTreeView : TreeView
    {
        public event RoutedEventHandler ItemLostLogicFocus;
    
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
    
            var itemContainerStyle = new Style
            {
                TargetType = typeof(TreeViewItem),
            };
    
            #region Binding
    
            var expandedBinding = new Binding("IsExpanded")
            {
                Mode = BindingMode.TwoWay,
            };
    
            var selectedBinding = new Binding("IsSelected")
            {
                Mode = BindingMode.TwoWay,
            };
                
            #endregion
    
            #region Setters
    
            itemContainerStyle.Setters.Add(new Setter
            {
                Property = TreeViewItem.IsExpandedProperty,
                Value = expandedBinding
            });
            itemContainerStyle.Setters.Add(new Setter
            {
                Property = TreeViewItem.IsSelectedProperty,
                Value = selectedBinding
            });
    
            #endregion
                
            #region EventSetters
    
            itemContainerStyle.Setters.Add(new EventSetter
            {
                Event = LostFocusEvent,
                Handler = new RoutedEventHandler(ItemLostLogicFocusHandler)
    
            });
                        
            #endregion
                 
            ItemContainerStyle = itemContainerStyle;
        }
    
        private void ItemLostLogicFocusHandler(Object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (ItemLostLogicFocus != null)
                ItemLostLogicFocus(sender, e);
        }
    }
