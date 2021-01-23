            datagrid.Columns.Add(new DataGridComboBoxColumn()
            {
                Width = 100,
                Header = "Product Code",
                SelectedValuePath="Product_Id",
                DisplayMemberPath="Product_Code",
                SelectedValueBinding = new System.Windows.Data.Binding()
                {
                    Path = new PropertyPath("Product_Id"), 
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, 
                    ValidatesOnDataErrors = true
                }
            });
