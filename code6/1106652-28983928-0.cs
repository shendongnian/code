    public void sendstudy(string sid, DataRow row)       
    { 
      // row added to TableObject
      this.datatableobject.Rows.Add(row);
      // Row added to dataGrid2 - as its the same obj we added row to in last step.
      dataGrid2.ItemsSource = this.datatableobject.DefaultView;
      tabControl1.SelectedIndex = 1;
      // I don't know how many rows are there, or may be you want to iterate on datatableobject instead ?
      foreach (DataRowView rowww in dataGrid2.Items)
      {
        // text will be different for all other rows but the one you added
        string text = rowww.Row.ItemArray[1].ToString();
        // if would set for your row if text mathches
        if (text == sid)
        {
            System.Windows.Forms.MessageBox.Show("ALREADY");
            return;
        }
      }
    }
