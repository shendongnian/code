    internal static void UpdateDxLibraryTx(PhysicalExam.DX newdx, PhysicalExam.DX olddx)
        {
            String Unique_Violation = "23505";
            // nothing to change.
            if (olddx.description == null) return;  
            PhysicalExam.DX oldDx = (PhysicalExam.DX)olddx;
            // the server structure was created in MainWindow on initialization.
            string connect = server.connection_string;
            string update = " update icd9 set cicd9='" + newdx.icd9 + "', cdesc= '" + newdx.description.ToLower().Trim() + "'" +
                    " ,chronic ='" + newdx.chronic + "' ,modified='" + DateTime.Now + "'" +
                    " where cicd9 ='" + oldDx.icd9 + "'" +
                    " and trim(cdesc) ='" + oldDx.description.ToLower().Trim() + "' and chronic ='" + oldDx.chronic + "';";
            string getchildtables = " select confrelid::regclass, af.attname as fcol,   "+ 
                                    " conrelid::regclass, a.attname as col              "+
                                    " from pg_attribute af, pg_attribute a,             "+
                                    " (select conrelid,confrelid,conkey[i] as conkey, confkey[i] as confkey "+
                                    " from (select conrelid,confrelid,conkey,confkey,   "+
                                    " generate_series(1,array_upper(conkey,1)) as i     "+
                                    " from pg_constraint where contype = 'f') ss) ss2   "+
                                    " where af.attnum = confkey and af.attrelid = confrelid and             "+ 
                                    " a.attnum = conkey and a.attrelid = conrelid "+
                                    " AND confrelid::regclass = 'ICD9'::regclass AND ( af.attname = 'cicd9' OR af.attname ='cdesc');";
            string sf = " update {0} set cicd9= '"+ newdx.icd9 +"' ,cdesc= '"+ newdx.description.ToLower().Trim() +"',"   +
                            " chronic = '"+newdx.chronic+"', modified= '"+ DateTime.Now +"'"                    +
                            " where cicd9 = '"+ oldDx.icd9 +"' and trim(cdesc)= '"+ oldDx.description.ToLower().Trim() +"' and chronic ='"+ oldDx.chronic +"';";
            string delete = "Delete from icd9 where trim(cicd9) = '" + oldDx.icd9.Trim() + "'" +
                            " and trim(cdesc)='" + oldDx.description.Trim() + "' and chronic = '"+ oldDx.chronic +"';";
                       
            // NpsqlConnection is unmanaged code...should use a using() block.
            using (NpgsqlConnection pgConnection = new NpgsqlConnection(connect))
            {
                try
                {
                    pgConnection.Open();
                    // Connection successful
                    // Create a new transaction
                    using (NpgsqlTransaction pgTransaction = (NpgsqlTransaction)pgConnection.BeginTransaction())
                    {
                        try
                        {
                            using (NpgsqlCommand updateCMD = new NpgsqlCommand(update, pgConnection, pgTransaction))
                            {
                                updateCMD.ExecuteNonQuery();
                            }
                            //Commit transaction. Hope it works!  Will fail for unique key violation.
                            pgTransaction.Commit();
                        }
                        catch (NpgsqlException ex)
                        {
                            pgTransaction.Rollback();
                            if (ex.Code == Unique_Violation)            
                            {                                
                                try
                                {
                                    using (NpgsqlDataAdapter children = new NpgsqlDataAdapter(getchildtables,pgConnection))   
                                    {
                                        DataSet ds = new DataSet();
                                        children.Fill(ds);
                                        DataView dv = new DataView();
                                        dv.Table = ds.Tables[0];
                                        foreach (DataRowView drv in dv)
                                        {
                                            string childtable = (string)drv[2];
                                            string updatechild = String.Format(sf, childtable);
                                            NpgsqlCommand updateCMD = new NpgsqlCommand(updatechild, pgConnection);
                                            int k = updateCMD.ExecuteNonQuery();
                                        }
                                        /* all tables now point to new value. remove old value from parent table. */
                                        NpgsqlCommand deleteCMD = new NpgsqlCommand(delete, pgConnection);
                                        int j = deleteCMD.ExecuteNonQuery();
                                    }
                                }
                                catch (NpgsqlException ex1)
                                {
                                    string error = ex1.Message;
                                    throw;
                                }
                                
                            }
                            else
                                throw;
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw;
                }
            }
        }
