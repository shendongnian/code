            for (int i = 0; i < dsProcesses.Tables[0].Rows.Count; i++)
            {
                strprocessid = strprocessid + dsProcesses.Tables[0].Rows[i]["ProcessID"].ToString() + ",";
             }
            strprocessid = strprocessid.TrimEnd(',');
