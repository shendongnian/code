    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string MyId = DataBinder.Eval(e.Row.DataItem, "ColumnName").ToString();
                        string Location = ResolveUrl("~/Your.aspx") + "?ColumName=" + MyId;
                        e.Row.Attributes["onClick"] = string.Format("javascript:window.location='{0}';", Location);
                        e.Row.Style["cursor"] = "pointer";
                    }
                }
