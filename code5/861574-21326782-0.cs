            DataView dv = new DataView(dt);
            if{dv.Table.Rows.Count > 10)
            {
                 PagedDataSource pgitems = new PagedDataSource();
                 pgitems.DataSource = dv;
                 pgitems.AllowPaging = true;
                 pgitems.PageSize = 2;
                 pgitems.CurrentPageIndex = PageNumber;               
                 rptPaging.Visible = true;
                 ArrayList pages = new ArrayList();
                 for (int i = 0; i < pgitems.PageCount; i++)
                       pages.Add((i + 1).ToString());
                 rptPaging.DataSource = pages;
                 rptPaging.DataBind();
            
           
            }
            else
            {
                rptPaging.Visible = false;
            }
