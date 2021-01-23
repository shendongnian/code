                  for (var i = 0; i < rsmenu.Tables[0].Rows.Count; i++)
                  {
                      foreach (MenuItem item in MnuUserManagement.Items)
                      {
           if (item.Text == rsmenu.Tables[0].Rows[i]["optionName"].ToString())
                          {
                              item.Enabled = true;
