        private DataTable dt = new DataTable("manager");
        private DataSet data_set = new DataSet("Test");
        private static int _stagiaireid = 0;
        public static int StagiaireID { get { return _stagiaireid++; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt.Columns.Add("id ", typeof(int));
                dt.Columns.Add("electro ", typeof(string));
                dt.Columns.Add("sn", typeof(string));
                dt.Columns.Add("date ", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("marque ", typeof(string));
                data_set.Tables.Add(dt);
                GridView1.DataSource = data_set.Tables["manager"];
                this.ViewState["ds"] = data_set;
                GridView1.DataBind();
            }
            else
            {
                data_set = (DataSet)ViewState["ds"];
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String electro = TextBox1.Text;
            String sn = TextBox2.Text;
            String date = TextBox3.Text;
            String email = TextBox4.Text;
            String marque = DropDownList1.SelectedValue.ToString();
            if (aide.nom_pre(email) == true)
            {
                Label1.Text = "Email Juste";
            }
            else
            {
                Label1.Text = "Email Faux";
                return;
            }
            data_set.Tables["manager"].Rows.Add(StagiaireID, electro, sn, date, email, marque);       
            GridView1.DataSource = data_set.Tables["manager"];
            GridView1.DataBind();
            this.ViewState["ds"] = data_set;
        }
