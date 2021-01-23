    internal enum DataType
    {
        None = 0,
        Decimal
    }
    internal enum Operator
    {
        Equal,
        GreaterThan,
        None
    }
    public partial class _Default : Page
    {
        private DataType DataType
        {
            get
            {
                object dataType = ViewState["DataType"];
                if (dataType != null) return (DataType)dataType;
                return DataType.None;
            }
            set { ViewState["DataType"] = value; }
        }
        private int? DataTypeIndex
        {
            get { return ViewState["DataTypeIndex"] as int?; }
            set { ViewState["DataTypeIndex"] = value; }
        }
        private Operator Operator
        {
            get
            {
                var @operator = ViewState["Operator"];
                if (@operator != null)
                    return (Operator)@operator;
                return Operator.None;
            }
            set { ViewState["Operator"] = value; }
        }
        private void BindDropDownLists()
        {
            column_list_for_filter.ConnectionString = connection;
            string item = "--Select--";
            column_list_for_filter.SelectCommand = "SELECT DATA_TYPE + '_' + convert(varchar(10), ROW_NUMBER() OVER(ORDER BY DATA_TYPE))as DATA_TYPE, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = 'RESULT' AND COLUMN_NAME IN ('Column1','Column2','Column3','Column4'))";
            DropDownList5.DataTextField = "COLUMN_NAME";
            DropDownList5.DataValueField = "DATA_TYPE";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, item);
        }
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTypeIndex = DropDownList5.SelectedIndex;
            if (DropDownList5.SelectedValue.Contains("decimal"))
            {
                DataType = DataType.Decimal;
            }
            CreateDataTypeControl();
            //else if (DropDownList5.SelectedValue.Contains("varchar"))
            //{
            //DataType = DataType.Varchar;
            //}
            //else if (DropDownList5.SelectedValue.Contains("datetime"))
            //{
            //DataType = DataType.DateTime;
            //}
            //else if (DropDownList5.SelectedValue.Contains("int"))
            //{
            //DataType = DataType.Integer;
            //}
        }
        protected void Range_DDL_Decimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            switch (ddl.SelectedIndex)
            {
                case 1:
                    Operator = WebApplication1.Operator.Equal;
                    break;
            }
            CreateRangeControls();
        }
        protected void createdynamiccontrols_decimal()
        {
            int i = DataTypeIndex.GetValueOrDefault();
            ++i;
            TableRow row = new TableRow();
            row.ID = "TableRow_";
            TableCell cell1 = new TableCell();
            cell1.ID = "TableCell_";
            DropDownList Range_DDL_Decimal = new DropDownList();
            Range_DDL_Decimal.ID = "RandeDDL_Decimal" + i.ToString();
            Range_DDL_Decimal.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Range_DDL_Decimal.Items.Insert(1, new ListItem("Equal", "Equal"));
            Range_DDL_Decimal.Items.Insert(2, new ListItem("NotEqual", "NotEqual"));
            Range_DDL_Decimal.Items.Insert(3, new ListItem("greater than", "greater than"));
            Range_DDL_Decimal.Items.Insert(4, new ListItem("lesser than", "lesser than"));
            Range_DDL_Decimal.Items.Insert(5, new ListItem("greater than or equal to", "greater than or equal to"));
            Range_DDL_Decimal.Items.Insert(6, new ListItem("lesser than or equal to", "lesser than or equal to"));
            Range_DDL_Decimal.Items.Insert(7, new ListItem("Contains", "Contains"));
            Range_DDL_Decimal.Items.Insert(8, new ListItem("Is Null", "Is Null"));
            Range_DDL_Decimal.Items.Insert(9, new ListItem("Is Not Null", "Is Not Null"));
            Range_DDL_Decimal.Items.Insert(10, new ListItem("Between", "Between"));
            Range_DDL_Decimal.SelectedIndexChanged += new System.EventHandler(Range_DDL_Decimal_SelectedIndexChanged);
            Range_DDL_Decimal.AutoPostBack = true;
            cell1.Controls.Add(Range_DDL_Decimal);
            //// Add the TableCell to the TableRow  
            row.Cells.Add(cell1);
            dynamic_filter_table.Rows.Add(row);
            dynamic_filter_table.EnableViewState = true;
            ViewState["dynamic_filter_table"] = true;
        }
        protected void CreateRangeTextBoxes()
        {
            int j = DataTypeIndex.GetValueOrDefault();
            ++j;
            TableCell cell2 = new TableCell();
            cell2.ID = "Range";
            TextBox tb1 = new TextBox();
            TextBox tb2 = new TextBox();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            // Set a unique ID for each TextBox added      
            tb1.ID = "lowerbound_" + j.ToString();
            tb2.ID = "upperbound_" + j.ToString();
            lbl1.Text = "LowerBound:";
            lbl1.Font.Size = FontUnit.Point(10);
            lbl1.Font.Bold = true;
            lbl1.Font.Name = "Arial";
            lbl2.Text = "UpperBound:";
            lbl2.Font.Size = FontUnit.Point(10);
            lbl2.Font.Bold = true;
            lbl2.Font.Name = "Arial";
            cell2.Controls.Add(lbl1);
            cell2.Controls.Add(tb1);
            cell2.Controls.Add(lbl2);
            cell2.Controls.Add(tb2);
            TableRow rowtwo = dynamic_filter_table.FindControl("TableRow_") as TableRow;
            rowtwo.Cells.Add(cell2);
            dynamic_filter_table.Rows.Add(rowtwo);
            dynamic_filter_table.EnableViewState = true;
            ViewState["dynamic_filter_table"] = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int j = DropDownList5.SelectedIndex;
            ++j;
            Panel6.Visible = true;
            JQGrid9.Visible = true;
            Find Control not working
            TextBox lowerboundd = dynamic_filter_table.FindControl("lowerbound_" + j.ToString()) as TextBox;
            TextBox upperbound = dynamic_filter_table.FindControl("upperbound_" + j.ToString()) as TextBox;
            DropDownList range = dynamic_filter_table.FindControl("RandeDDL_Decimal" + j.ToString()) as DropDownList;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM RESULT WHERE " + DropDownList5.Text + DDL2.Text + " >= " + lowerboundd.Text + " AND " + DropDownList5.Text + " <= " + upperbound.Text, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            Session["DataforSearch"] = ds.Tables[0];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel6.Visible = false;
            JQGrid9.Visible = false;
            if (Session["DataforSearch"] != null)
            {
                Panel6.Visible = true;
                JQGrid9.Visible = true;
                JQGrid9.DataSource = Session["DataforSearch"] as string;
            }
            CreateDataTypeControl();
            CreateRangeControls();
        }
        void CreateDataTypeControl()
        {
            switch (DataType)
            {
                case DataType.Decimal:
                    createdynamiccontrols_decimal();
                    break;
            }
        }
        void CreateRangeControls()
        {
            switch (Operator)
            {
                case WebApplication1.Operator.GreaterThan:
                case Operator.Equal:
                    CreateRangeTextBoxes();
                    break;
            }
        }
    }
