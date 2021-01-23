        using (SqlConnection conn = new SqlConnection(GetSQLAzureConnectionStringiMae()))
        {
            conn.Open();
            using (SqlTransaction tr = conn.BeginTransaction())
            {
                try
                {
                    using (SqlCommand SQLCmd = new SqlCommand("DELETE_t_Promemoria", conn))
                    {
                        SQLCmd.CommandType = CommandType.StoredProcedure;
                        SQLCmd.Parameters.Add("@CodScuola", mCodiceScuolaiMae);
                        SQLCmd.Transaction = tr;
                        SQLCmd.ExecuteNonQuery();
                    }
                    using (SqlBulkCopy SQLCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tr))
                    {
                        SQLCopy.DestinationTableName = "t_Promemoria";
                        SQLCopy.WriteToServer(dtOccupazioni);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                }
            }
            conn.Close();
        }
        return true;
    }
