    if (!IsPostBack)
            {
             using (SqlDataAdapter adapter = new SqlDataAdapter("select distinct MainAccount,MainDescription from chart", db.con))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
    
                List<Columns> list = new List<Columns>();
    
                foreach (DataRow dr in datatable.Rows)
                {
                    list.Add(new Columns { MainAccount =dr[0].ToString() ,
                                          MAinDescription =  dr[1].ToString()});
                }
    
                list = list.OrderBy(a => a.MainAccount).ToList();
                DropDownList1.DataSource = list;
    
                DropDownList1.DataBind();
    
            }
        }
