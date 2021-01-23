    public void TryGridRefresh()
    {
       int IDToFind = Convert.ToInt32(txt_IdUnique.Text);
    
       if (IDToFind > -1 and dataGrid1.ItemsSource is DataView )
       {
          foreach( DataRowView drv in (DataView)dataGrid1.ItemsSource )
             if ((int)drv["IdUnique"] == IDToFind)
             {
                // This is the data row view record you want...
                dataGrid1.SelectedItem = drv;
             }
       }
    }
