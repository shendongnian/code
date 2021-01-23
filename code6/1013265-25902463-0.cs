    using (var conn = OracleConnect(username, password))
                {
                    conn.Open();
                    string cmd = "SELECT DISTINCT(ENTITYID) FROM MY.DATABASE WHERE ITEM_ID =@ItemID ";
                    using (var oleCmd = new OleDbCommand(cmd, conn))
                    {
                        oleCmd.Parameters.AddWithValue("@ItemID", "itemid");
                        using (var oleRead = oleCmd.ExecuteReader())
                        {
                            while (oleRead.Read())
                            {
                                string entity = oleRead["ENTITYID"].ToString();
                                if (!string.IsNullOrEmpty(entity)) _entityid.Add(entity);
                            }
                        }
                    }
                }
