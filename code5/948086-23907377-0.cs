    namespace StackOverflow
    {
        public class CustomColumn : DataGridBoundColumn
        {
            protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock block = new TextBlock();
            CustomColumn column = (CustomColumn)cell.Column;
            Binding binding = (Binding)column.Binding;
            if (binding != null)
            {
                // Binde den ausgewählten Wert
                Binding cellBinding = new Binding(binding.Path.Path);
                cellBinding.Source = dataItem;
                cellBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                cellBinding.ValidatesOnDataErrors = true;
                cellBinding.ValidatesOnExceptions = true;
                cellBinding.NotifyOnValidationError = true;
                cellBinding.ValidatesOnNotifyDataErrors = true;
                cellBinding.Mode = BindingMode.OneWay;
                block.SetBinding(TextBlock.TextProperty, cellBinding);
            }
            return block;
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            TextBox box = new TextBox();
            CustomColumn column = (CustomColumn)cell.Column;
            Binding binding = (Binding)column.Binding;
            if (binding != null)
            {
                // Binde den ausgewählten Wert
                Binding cellBinding = new Binding(binding.Path.Path);
                cellBinding.Source = dataItem;
                cellBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                cellBinding.ValidatesOnDataErrors = true;
                cellBinding.ValidatesOnExceptions = true;
                cellBinding.NotifyOnValidationError = true;
                cellBinding.ValidatesOnNotifyDataErrors = true;
                cellBinding.Mode = BindingMode.TwoWay;
                box.SetBinding(TextBlock.TextProperty, cellBinding);
            }
                DataObject.AddPastingHandler(box, PastingHandler);
                return box;
            }
    
            private void PastingHandler(object sender, DataObjectPastingEventArgs e)
            {
                TextBox textBox = sender as TextBox;
                if (textBox == null)
                {
                    return;
                }
    
                if (e.DataObject.GetDataPresent(typeof(string)))
                {
                    //Read input
                    string pasteText = e.DataObject.GetData(typeof(string)) as string;
                    // Kommt ein neuer String zurück, wird dieser eingefügt und die ursprüngliche Operation abgebrochen.
                    if (!string.IsNullOrEmpty(pasteText))
                    {
                        // Neuen Text einbringen
                        textBox.Text = pasteText;
                        // Restliches Einfügen abbrechen
                        e.CancelCommand();
                    }
                }
            }
        }
    }
