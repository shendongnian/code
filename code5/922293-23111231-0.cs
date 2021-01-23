    using (var response = request.GetResponse())
    {
        DataSet dsTable = new DataSet();
        dsTable.ReadXml(response.GetResponseStream(), XmlReadMode.Auto); 
        lstMaasBatches= (from DataRow row in dsTable.Tables[0].Rows
                    select new MAASBatch
                    {
                        BatchName = row["BatchName"].ToString(),
                        BatchId = Convert.ToInt32(row["MAASBatch_Id"].ToString())                        
                    }).ToList();
        foreach (MAASBatch batch in lstMaasBatches)
        {
            int batchID = batch.BatchId;
            List<MAASUsers> lst = (from DataRow row in dsTable.Tables[2].Rows
                                               where row.Field<int>("Users_Id") == batchID 
                         select new MAASUsers
                         {
                             ID = Convert.ToInt32(row["ID"].ToString()),
                             firstName = Convert.ToString(row["FirstName"].ToString()),
                             lastName = Convert.ToString(row["LastName"].ToString()),
                             migrationStatus = row["migrationStatus"].ToString(),
                             sourceEmail = Convert.ToString(row["SourceEmail"].ToString()),
                             sourceAgentID = Convert.ToInt32(row["sourceTenantID"].ToString()),
                             targetEmail = Convert.ToString(row["TargetEmail"].ToString()),
                             targetAgentID = Convert.ToInt32(row["targetTenantID"].ToString()),
                         }).ToList();
                        batch.Users = lst;
                    }                   
         }
    }
