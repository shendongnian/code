     if (myreader["category"] != DBNull.Value)
           {
              string sName1 = myreader.GetString("category");
              call2.Add(sName1);
              comboBox1.Items.Add(sName1);
           };
                               
      if (myreader["subcategory"] != DBNull.Value)
           {
              string sName2 = myreader.GetString("subcategory");
              call.Add(sName2);
              comboBox2.Items.Add(sName2);
           }; 
