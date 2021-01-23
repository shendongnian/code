    while (dr2.HasRows) 
    {
      Object[] output = new Object[dr2.FieldCount];
      dr2.GetValues(output);
          
      MessageBox.Show(output[2].ToString());
    }
