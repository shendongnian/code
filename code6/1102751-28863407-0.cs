     public class ExtendedTreeView : TreeView
    {
        public ExtendedTreeView()
            : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
            this.PreviewMouseRightButtonDown += ExtendedTreeView_PreviewMouseRightButtonDown;
            
        }
        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }
        }
        void ExtendedTreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem =
                      VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                SetValue(RightClickedItem_Property, treeViewItem.DataContext);
                e.Handled = true;
            }
        }
        static T VisualUpwardSearch<T>(DependencyObject source) where T : DependencyObject
        {
            DependencyObject returnVal = source;
            while (returnVal != null && !(returnVal is T))
            {
                DependencyObject tempReturnVal = null;
                if (returnVal is Visual || returnVal is Visual3D)
                {
                    tempReturnVal = VisualTreeHelper.GetParent(returnVal);
                }
                if (tempReturnVal == null)
                {
                    returnVal = LogicalTreeHelper.GetParent(returnVal);
                }
                else returnVal = tempReturnVal;
            }
            return returnVal as T;
        }
        public object RightClickedItem_
        {
            get { return (object)GetValue(RightClickedItem_Property); }
            set { SetValue(RightClickedItem_Property, value); }
        }
        public static readonly DependencyProperty RightClickedItem_Property =
            DependencyProperty.Register("RightClickedItem_", typeof(object), typeof(ExtendedTreeView), new PropertyMetadata(null));
               
        public object SelectedItem_
        {
            get { return (object)GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
