     private void tb_ControlAdded(object sender, ControlEventArgs e)
        {
            
            TextBox autoText = e.Control as TextBox;
            if (autoText != null)
            {
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                addItems(DataCollection);
                autoText.AutoCompleteCustomSource = DataCollection;
            }
        }
