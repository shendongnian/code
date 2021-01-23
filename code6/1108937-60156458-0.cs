    DataTable dt = Execute_Query(Connection, query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        J = dt.Rows.Count;
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++) 
                            {
                                sb.Append(dt.Rows[i][j] + ",");
                            }
                            sb.Append("\n");
                        }
                        Logger.Info(sb.ToString());
                    }
                }
