    void myDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DataSource = displayDataSource;
            }
        }
 
