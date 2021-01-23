    closedList = new List<list>();
    draftList = new List<list>();
    if (ds.Tables.Count != 0)
    {
       foreach (DataRow dr in ds.Tables[0].Rows)
       {
           List ls = new List();
           if (dr["list_id"] != DBNull.Value)
           {
                ls.ID = Convert.ToInt32(dr["list_id"]);
                //I have more this is just for example
                if(dr["WhateverIndicatesClosed"] == true)
                {
                   closedList.Add(ls);
                }else{
                   draftList.Add(ls);
                }
           }
       }
    }
    gvDraft.DataSource = draftList;
    gvDraft.DataBind();
    gvClosed.DataSource = closedList;
    gvClosed.DataBind();
   
