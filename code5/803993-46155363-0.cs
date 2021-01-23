    for(int i = 0; i < dtUser.Rows.Count; i++)
                    {
                        if (dtUser.Rows[i]["DataKeyName"] == req.value)
                        {
                            dtUser.Rows.Remove(dtUser.Rows[i]);
                            i--;
                           
                        }
                    }
