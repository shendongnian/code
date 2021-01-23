    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace ReorderableListBox
    {
        public class ReorderableListBox : ListBox
        {
            private bool _canDrag;
            private int _sourceIndex;
            private int _targetIndex;
    
            protected override void OnSelectionChanged(SelectionChangedEventArgs e)
            {
                base.OnSelectionChanged(e);
    
                if (Items == null || SelectedItem == null) return;
                if (_canDrag)
                    _sourceIndex = Items.IndexOf(SelectedItem);
    
                if (_targetIndex == -1 || _sourceIndex == -1 || !_canDrag) return;
                var item1 = (ListBoxItem)Items[_targetIndex];
                var item2 = (ListBoxItem)Items[_sourceIndex];
                object content1 = item1.Content;
                object content2 = item2.Content;
                item1.Content = content2;
                item2.Content = content1;
    
                _canDrag = false;
            }
    
            protected override void OnPreviewMouseMove(MouseEventArgs e)
            {
                base.OnPreviewMouseMove(e);
    
                var canDrag = e.LeftButton == MouseButtonState.Pressed;
                if (canDrag && Items != null && SelectedItem != null)
                    _targetIndex = Items.IndexOf(SelectedItem);
                _canDrag = canDrag;
            }
        }
    }
