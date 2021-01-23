        /// <summary>
        /// This class help to create data grid cell which only support interger numbers.
        /// </summary>
        public class DataGridNumericColumn : DataGridTextColumn
        {
            protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
            {
                TextBox edit = editingElement as TextBox;
    
                if (edit != null) edit.PreviewTextInput += OnPreviewTextInput;
    
                return base.PrepareCellForEdit(editingElement, editingEventArgs);
            }
    
            private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
            {
                int value;
    
                if (!int.TryParse(e.Text, out value))
                    e.Handled = true;
            }
        }
