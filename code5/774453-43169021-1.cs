     public static void ShowAllUsers(DataGridView grdView,string table, params string[] fields) {
    
    
                DataRowCollection userSet = getAllUsers(table);
                foreach (DataRow user in userSet)
                {
    
                    grdView.Rows.Add(user[fields[0]],
                        user[fields[1]],
                        user[fields[2]],
                        user[fields[3]]);
    
                }
    
    
            }
