        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridTextColumn textColumn;
            if ((textColumn = e.Column as DataGridTextColumn) != null)
            {
                var binding = textColumn.Binding;
                var clone = binding.CloneBinding();
                clone.FallbackValue = "-----";
                clone.TargetNullValue = "-----";
                textColumn.Binding = clone;
            }
        }
