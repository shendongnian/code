    public void myComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      if (myComboBox.SelectedIndex <= 0) return;
      var newConnection = ((ComboItemExample)myComboBox.Items[myComboBox.SelectedIndex]).ConnectionString;
      // now use "newConnection" as your connection string. Save in a local member
      //    or pass directly into the call to create the database connection.
    }
