    SqlDataAdapter menuDataAdapter = new SqlDataAdapter("SELECT * FROM RestaurantsMenu1;       "SELECT * FROM RestaurantsMenu2;"SELECT * FROM RestaurantsMenu3;", connection);
    menuDataAdapter.TableMappings.Add("Table1", "RestaurantsMenu1");
    menuDataAdapter.TableMappings.Add("Table2", "RestaurantsMenu2");
    menuDataAdapter.TableMappings.Add("Table3", "RestaurantsMenu3");
    for(int i=0;i<menuDataSet.Tables.Count;i++)
    {
      foreach (DataRow menuDR in menuDataSet.Tables[i].Rows)
      {
        Rst_Menu.Add(new RestaurantsMenu(){Restaurant_ID = int .Parse (menuDR[0].ToString()), RestaurantName =menuDR[1].ToString(),
        Menu =menuDR[2].ToString(), Price=int .Parse (menuDR[3].ToString()) } );
      }
    }
