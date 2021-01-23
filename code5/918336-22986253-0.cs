     private void datagrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (datagrid.CurrentCell.ColumnIndex == 4)
            {
                if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
                {
                    DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                    cbo.Validating += new CancelEventHandler(cbo_Validating);
                    cbo.SelectedIndexChanged += new EventHandler(SpacingComBox_SelectedIndexChanged);
                }
                
            }
        }
