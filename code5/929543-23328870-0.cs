    int i = 1;
    using (MySqlDataReader mysqlData = con.Select(query))
    {
         if (mysqlData.HasRows)
         {
              while (mysqlData.Read())
              {
                  int id = mysqlData.GetInt32("category_id");
                  String name = mysqlData.GetString("category_code");
                  productCategory.Items.Insert(i++, name);
               }
          }
     }
