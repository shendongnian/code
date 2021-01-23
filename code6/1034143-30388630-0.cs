    private int gvDataCount
        {
            get
            {
                object count = ViewState["gvDataCount"];
                if (count == null)
                    count = gvTest.PageSize;
                return Convert.ToInt32(count);
            }
            set
            {
                ViewState["gvDataCount"] = value;
            }
        }
    private void BindData()
        {
           
            //....
            var list = items.Skip(gvTest.PageIndex * gvTest.PageSize).Take(gvTest.PageSize).ToList();
            this.gvDataCount = list.Count;
            gvTest.DataSource = list;
            gvTest.VirtualItemCount = items.Count;
            gvTest.DataBind();
        }
    protected void gvTest_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            if (e.Row.RowIndex > this.gvDataCount)
                e.Row.Visible = false;
        }
