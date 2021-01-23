     private void Loadproduction()
     {
         .....
            prodline.DataTable2.Reset();//Reset removes all data, indexes, relations, and columns of the table
            myadapter.Fill(prodline, "DataTable2");
            comboBox2.DataSource = prodline.DataTable2;
     }
