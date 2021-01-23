    public int addBulkLeadStages(List<LeadStage> allLeadStages)
    {
        //throw new NotImplementedException();
        SqlConnection connection;
        SqlCommand cmd;
        int effectedRows = 0;
        int rowsCount = 0;
        int updatedRowsCount = 0;
        using (TransactionScope trans = new TransactionScope())
        {
            using (connection = new SqlConnection(SalesForceDBManager.getConnectionString(SalesForceDB.CONNECTION_STRING)))
            {
                //Open Connection
                connection.Open();                
                //Craete Command
                cmd = connection.CreateCommand();
                int noOfLeadStages = allLeadStages.Count;
                for (int i = 0; i < noOfLeadStages; i++)
                {
                    //Check If entry already available
                    if (isLeadStageRecordExist(allLeadStages[i].ID,connection))
                    {
                        //Update Existing Record
                        updatedRowsCount = updateLeadStage(connection, allLeadStages[i].ID, allLeadStages[i]);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO " + SalesForceDB.LeadStage.TABLE_LEAD_STAGE + "(" +
                            SalesForceDB.LeadStage.COLUMN_ID + "," + SalesForceDB.LeadStage.COLUMN_NAME + "," +
                            SalesForceDB.LeadStage.COLUMN_COMMENTS_REMARKS + "," + SalesForceDB.LeadStage.COLUMN_ENTRY_POINT + "," +
                            SalesForceDB.LeadStage.COLUMN_EXIT_POINT + "," + SalesForceDB.CommonColumns.COLUMN_IS_ACTIVE + "," +
                            SalesForceDB.LeadStage.COLUMN_SEQUENCE_NO + "," + SalesForceDB.LeadStage.COLUMN_STAGE_DESCRIPTION + "," +
                            SalesForceDB.CommonColumns.COLUMN_CREATED_BY + "," + SalesForceDB.CommonColumns.COLUMN_CREATED_DATE + "," +
                            SalesForceDB.CommonColumns.COLUMN_LAST_MODIFIED_BY + "," + SalesForceDB.CommonColumns.COLUMN_LAST_MODIFIED_DATE + ")" +
                            " VALUES (@ID,@StageName,@CommentsRemarks,@EntryPoint,@ExitPoint,@IsActive,@SequenceNo,@StageDesc,@CreatedBy,@CreatedDate," +
                            "@LastModifiedBy,@LastModifiedDate)";
                        //Adding Command Parameters
                        cmd.Parameters.AddWithValue("@ID", allLeadStages[i].ID);
                        cmd.Parameters.AddWithValue("@StageName", allLeadStages[i].Name);
                        cmd.Parameters.AddWithValue("@CommentsRemarks", allLeadStages[i].Comments);
                        cmd.Parameters.AddWithValue("@EntryPoint", allLeadStages[i].EntryPoint);
                        cmd.Parameters.AddWithValue("@ExitPoint", allLeadStages[i].ExitPoint);
                        cmd.Parameters.AddWithValue("@IsActive", allLeadStages[i].IsActive);
                        cmd.Parameters.AddWithValue("@SequenceNo", allLeadStages[i].SequenceNo);
                        cmd.Parameters.AddWithValue("@StageDesc", allLeadStages[i].Description);
                        cmd.Parameters.AddWithValue("@CreatedDate", allLeadStages[i].CreatedDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", allLeadStages[i].CreatedBy);
                        cmd.Parameters.AddWithValue("@LastModifiedBy", allLeadStages[i].LastModifiedBy);
                        cmd.Parameters.AddWithValue("@LastModifiedDate", allLeadStages[i].LastModifiedDate);
                        //Execute query
                        effectedRows = cmd.ExecuteNonQuery();
                        rowsCount += effectedRows;
                        cmd.Parameters.Clear();
                    }
                }
                trans.Complete(); // <-- THIS IS MISSING!
            }
            return rowsCount;
        }
    }
