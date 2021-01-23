     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select Name from aTable";
                DataTable dt = GetData(query);
                ddlCountries.DataSource = dt;
                ddlCountries.DataTextField = "Name";
                ddlCountries.DataValueField = "Name";
                ddlCountries.DataBind();
                ddlCountries.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        private DataTable GetData(string query, SqlParameter[] prms = null)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["demoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    if (prms != null)
                        cmd.Parameters.AddRange(prms);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select Name, Debit, Credit From aTable where Name=@Name";
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@name", SqlDbType.NVarChar);
            prms[0].Value = ddlCountries.SelectedItem.Value.ToString();
            DataTable dt = GetData(query, prms);
    
            string[] x = new string[dt.Rows.Count];
            decimal[] z = new decimal[dt.Rows.Count];
            decimal[] y = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
                z[i] = Convert.ToInt32(dt.Rows[i][2]);
            }
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = z });
            BarChart1.CategoriesAxis = string.Join(",", x);
            BarChart1.ChartTitle = string.Format("{0} -RunTimeReportChart", ddlCountries.SelectedItem.Value);
            if (x.Length > 20)
            {
                BarChart1.ChartWidth = (x.Length * 100).ToString();
            }
            BarChart1.Visible = ddlCountries.SelectedItem.Value != "";
    
        }
