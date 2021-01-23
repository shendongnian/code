        void UpdateGridViewData(bool Filtered=false, Dictionary<string,string> FiltersDict = null)
        {
            using (SqlCeConnection ClientsConn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["Conn_DB_RCL_CRM2014"].ConnectionString))
            {
                System.Data.Linq.Table<ContactsClients> db = null;
                IEnumerable<ContactsClients> IDB = null;
                BindingSource BS_Clients = new BindingSource();
                System.Reflection.MemberInfo[] AllDbTblClientsColumns = (System.Reflection.MemberInfo[])typeof(ContactsClients).GetProperties();
                using (DB_RCL_CRM2014Context Context = new DB_RCL_CRM2014Context(ClientsConn))
                {
                    if (!Filtered)
                    {
                        db = Context.ContactsClients;
                        BS_Clients.DataSource = db;
                    }
                    else
                    {
                        string fltr = "";
                        var and = "";
                        if (FiltersDict.Count > 1) and = "AND";
                        for (int i = 0; i < FiltersDict.Count; i++)
                        {
                            KeyValuePair<string, string> CurFltrKVP = FiltersDict.ElementAt(i);
                            if (i >= FiltersDict.Count-1) and = "";
                            for (int j = 0; j < AllDbTblClientsColumns.Length; j++)
                            {
                                
                                if (AllDbTblClientsColumns[j].Name.Equals(CurFltrKVP.Key))
                                {
                                    
                                    fltr += string.Format("{0} Like '%{1}%' {2} ", AllDbTblClientsColumns[j].Name, CurFltrKVP.Value, and);
                                   
                               
                                }
                            }
                        }
                        try
                        {
                            IDB = Context.ExecuteQuery<ContactsClients>(
                              "SELECT * " +
                              "FROM ContactsCosmeticsClients " +
                              "WHERE " + fltr
                                
                            );
                            BS_Clients.DataSource = IDB;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                    
                    GV_ClientInfo_Search.DataSource = BS_Clients;
                }
            }
        }
