    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       { 
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drv in dv)
            {
                IDLBL.Text = drv["ID"].ToString();
                Name.Text = drv["Name"].ToString();
                SName.Text = drv["SecondName"].ToString();
                Ocenka.Text = drv["Graduate"].ToString();
                Klass.Text = drv["Class"].ToString();
            }
            
        }
