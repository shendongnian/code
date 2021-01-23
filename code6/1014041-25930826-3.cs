     //check whether it's already inserted
      bool CheckDuplicateId()
      {
          foreach (ListViewItem lv in listView1.Items)
          {
              if (lv.SubItems[0].Text == cmbpid.SelectedItem.ToString())
              {
                  //there is a duplicate data
                  return true;
              }
          }
          //there is no duplicate data
          return false;
      }
      //insert data using text boxes to listview ctrl
      void InsertProductData()
      {
          foreach (Control x in this.Controls)
          {
              if (x is TextBox)
              {
                  //I'm not sure your control z-order
                  lvi.SubItems.Add(((TextBox)x).Text);
              }
          }
      }
