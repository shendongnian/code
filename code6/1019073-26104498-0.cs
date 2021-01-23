        public void ProcessRequests(int maxThreads = 5)
        {
            DataSet objDs = new DataSet();
            objDs = EnableFeatureDAO.SelectByStatus(strPendingStatus);
            if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
            {
                ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = maxThreads };
                Parallel.For(0, objDs.Tables[0].Rows.Count, options, (i) =>
                {
                    DataRow objDr = objDs.Tables[0].Rows[i];
                    //Business Object/ Business Layer Call
                    EnableFeatureBO objEnableFeatureBO = new EnableFeatureBO();
                    try
                    {
                        //Do updates by calling webservice internally here which has Stored Proc
                        //It has it's connection details to take care of Updates
                        //Backend is Oracle
                        // Order in which these are going doesn't matter as they open up a separate connection for each thread 
                        objEnableFeatureBO.EnableDisableFeatureExecuteScripts(
                            objDr[EnableFeatureDAO.COL_CUSTID],
                            objDr[EnableFeatureDAO.COL_ISICLIENTID],
                            objDr[EnableFeatureDAO.COL_CLIENTDBSCHEMA],
                            objDr[EnableFeatureDAO.COL_CLIENTDBSERVER]);
                    }
                    catch (Exception ex)
                    {
                        //log Exception
                    }
                });
            }
        }
