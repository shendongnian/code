            DataTable dt; //your datatable here
            DataView dv = dt.DefaultView;
            foreach (DataRow dr in dt.Rows)
            {
               
                if (Regex.IsMatch(dr["Column name of your IP"].ToString(), "regex to check  IP") == false)
                {
                   //Delete that row or something
                }
                else
                {
                   //Do something else
                }
            }
            DataTable tempTable = dv.ToTable();
           //where temptable is your sorted and updated datatable
