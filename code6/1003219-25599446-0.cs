    for (int i = 0; dtst_Theatrs.Tables[0].Rows.Count > i; i++)
       {
            Date_Check obj_Date_Check = new Date_Check();
            obj_Date_Check.Movie_Name = dtst_Theatrs.Tables[0].Rows[i]["Movie_Name"].ToString();
            obj_Date_Check.Record_Id = dtst_Theatrs.Tables[0].Rows[i]["Record_Id"].ToString();
             lst_Date_Check.Add(obj_Date_Check);
       }
