    private void bindTheGriView()
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Row Number", typeof(string)));
                dt.Columns.Add(new DataColumn("POS Id", typeof(string)));
                dt.Columns.Add(new DataColumn("Action", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
                for (int index = 0; index < m_listStrPendingListOfPOS.Count; index++)
                {
                    dr = dt.NewRow();
                    int iRowNo = index + 1;
                    dr["Row Number"] = iRowNo;
                    string strGridViewPOSId = m_listStrPendingListOfPOS[index];
                    dr["POS Id"] = strGridViewPOSId;
                    dr["Action"] = string.Empty;
                    //check for the flag. if the flag is true set status to Pending else to Associated
                    dr["Status"]=((Label)GridViewMultiplePOSAssociationId.Rows[index].FindControl("LabelStatusPendingPOSId")).Text;
                   dt.Rows.Add(dr);
                }
    
                ViewState["POSTable"] = dt;
                GridViewMultiplePOSAssociationId.DataSource = dt;
                GridViewMultiplePOSAssociationId.DataBind();
            }
