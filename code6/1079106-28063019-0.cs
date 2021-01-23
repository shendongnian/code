    DataSet dsSaved = null;
            DataSet ds = null;
            DataTable dt = null;
            DataSet dsDisplay = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dsSaved = manageSavedjob.GetJobByID(Convert.ToInt32(ds.Tables[0].Rows[i]["SavedJobID"].ToString()));
                dt = new DataTable();
                dt.Columns.Add("JobID");
                dt.Columns.Add("JobConID");
                dt.Columns.Add("jobTitle");
                dt.Columns.Add("jobInfo");
                dt.Columns.Add("priceFrom");
                dt.Columns.Add("priceTo");
                dt.Columns.Add("dateSent");
                dt.Columns.Add("lastUpdated");
                dt.Columns.Add("postUser");
                dt.Columns.Add("address");
                dt.Columns.Add("workers");
                DataRow workRow = dt.NewRow();
                workRow[0] = Convert.ToInt32(dsSaved.Tables[0].Rows[0]["JobID"].ToString());
                workRow[1] = Convert.ToInt32(dsSaved.Tables[0].Rows[0]["JobConID"].ToString());
                workRow[2] = dsSaved.Tables[0].Rows[0]["jobTitle"].ToString();
                workRow[3] = dsSaved.Tables[0].Rows[0]["jobInfo"].ToString();
                workRow[4] = Convert.ToInt32(dsSaved.Tables[0].Rows[0]["priceFrom"].ToString());
                workRow[5] = Convert.ToInt32(dsSaved.Tables[0].Rows[0]["priceTo"].ToString());
                workRow[6] = dsSaved.Tables[0].Rows[0]["dateSent"].ToString();
                workRow[7] = dsSaved.Tables[0].Rows[0]["lastUpdated"].ToString();
                workRow[8] = dsSaved.Tables[0].Rows[0]["postUser"].ToString();
                workRow[9] = dsSaved.Tables[0].Rows[0]["address"].ToString();
                workRow[10] = Convert.ToInt32(dsSaved.Tables[0].Rows[0]["workers"].ToString());
                dt.Rows.Add(workRow);
                dsDisplay.Tables.Add(dt);
            }
