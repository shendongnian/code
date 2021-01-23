    protected void GRVToppers_RowDataBound(object sender, GridViewRowEventArgs e)
            {
    
                    if (e.Row.RowType == DataControlRowType.Footer)
                    {
                        var dept = from n in ecme.DEPT_MASTER
                                   select new { n.DEPT_ID, n.DEPT_NAME };
    
                        DropDownList ddl = (DropDownList)e.Row.FindControl("ddladdnewDeptname");
    
                        ddl.DataTextField = "DEPT_NAME";
                        ddl.DataValueField = "DEPT_ID";
                        ddl.DataSource = dept.ToList();
                        ddl.DataBind();
                        ddl.Items.Insert(0, "--Select Department--");
                    }
    }
