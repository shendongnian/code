    public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        private void bindData()
        {
            
            string Query = "select TestItemID,TestItemName,TestItemValues,DefaultValues,TestID,ItemGroup,isnull(TestItemGroup,'-') as TestItemGroup, (ItemGroup + ' ' + TestItemValues) as Itm from Test_Items where TestID = '" + ViewState["id"].ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var rows = dt.AsEnumerable().Select(s => new { id = s.Field<string>("TestItemGroup"), }).Distinct().ToList();
            int count = rows.Count;
            if (dt.Rows.Count > 0)
            {
                StringBuilder build = new StringBuilder();
                foreach (var row in rows)
                {
                    string Name = row.id != "-" ? row.id : " ";
                    build.Append("<b>" + Name + "</b>");
                    DataTable dts = new DataTable();
                    dts = dt.Select("TestItemGroup = '" + row.id + "'").CopyToDataTable();
                    gvTemp.Visible = true;
                    gvTemp.DataSource = dts;
                    gvTemp.DataBind();
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvTemp.RenderControl(hw);
                    string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                    build.Append(gridHTML);
                    gvTemp.Visible = false;
                }
                litDataLoader.Text = build.ToString();
            }
        }
