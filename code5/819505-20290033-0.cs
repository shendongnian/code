        void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            BindingBase bindingBase = null;
            var dataGridBoundColumn = e.Column as DataGridBoundColumn;
            if (dataGridBoundColumn != null)
            {
                bindingBase = dataGridBoundColumn.Binding;
            }
            else
            {
                var dataGridComboBoxColumn = e.Column as DataGridComboBoxColumn;
                if (dataGridComboBoxColumn != null)
                    bindingBase = dataGridComboBoxColumn.SelectedItemBinding;
            }
            var binding = bindingBase as Binding;
            if (binding != null)
            {
                binding.NotifyOnTargetUpdated = true;
                e.Column.CellStyle = new Style(typeof(DataGridCell))
                {
                    Setters = 
                    {
                        new EventSetter(Binding.TargetUpdatedEvent, new EventHandler<DataTransferEventArgs>(OnDataGridCellBindingTargetUpdated))
                    }
                };
            }
        }
