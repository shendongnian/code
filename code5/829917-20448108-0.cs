    string ID = textBoxId.Text.Replace("'", "''");
    string last = textBoxLastName.Text.Replace("'","''");
    string first = textBoxFirstName.Text.Replace("'", "''");
    string address = textBoxAddress.Text.Replace("'", "''");
    BindingSource bs = new BindingSource();
    bs.DataSource = dataGridViewShowPeople.DataSource;
    bs.Filter = string.Format("Convert(ID, 'System.String') like '{0}%' AND " + 
                              "lastName like '%{1}"%' AND firstName like '{2}%' AND " + 
                              "address like '{2}%'", ID, last, first, address);
  
