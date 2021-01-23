            if (rs.Tables[0].Rows.Count > 0)
            {
                for (var i = 0; i < rs.Tables[0].Rows.Count; i++)
                {
                    
                    foreach (MenuItem childItem in item.ChildItems)
                    {
              if (childItem.Text == rs.Tables[0].Rows[i]["Optionname"].ToString())
                        {
                            childItem.Enabled = true;
                        }
                    }
                }
            }
                          }
                      }
                  }
 
              }
