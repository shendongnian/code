    public static void UpdateData<T>(List<T> list,string TableName)
    {
        DataTable dt = new DataTable("MyTable");
        dt = ConvertToDataTable(list);
        
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolSoulDataEntitiesForReport"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("", conn))
            {
                try
                {
                    conn.Open();
                    //Creating temp table on database
                    command.CommandText = "CREATE TABLE #TmpTable(...)";
                    command.ExecuteNonQuery();
                    //Bulk insert into temp table
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                    {
                        bulkcopy.BulkCopyTimeout = 660;
                        bulkcopy.DestinationTableName = "#TmpTable";
                        bulkcopy.WriteToServer(dt);
                        bulkcopy.Close();
                    }
                    // Updating destination table, and dropping temp table
                    command.CommandTimeout = 300;
                    command.CommandText = "UPDATE T SET ... FROM " + TableName + " T INNER JOIN #TmpTable Temp ON ...; DROP TABLE #TmpTable;";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception properly
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
