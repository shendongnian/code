        ManualSQConnWhere(DropDownList1, myTable, "Run_ID", CheckBox1);
        ManualSQConnWhere(DropDownList2, myTable, "Job_Status", CheckBox2);
        ManualSQConnWhere(DropDownList3, myTable, "Job_Plan", CheckBox3);
        protected string ManualSQConnWhere(DropDownList myList, string TableNameWeb2, string FieldName, CheckBox myCheckBox)
        {
            string ConnectionString = "Data Source=xxxxx;Initial Catalog=xxxxx;Integrated Security=True";
            cmdText = @"SELECT DISTINCT " + FieldName + " FROM " + TableNameWeb2;
            DataSet dbWeb2 = new DataSet();
            myList.AutoPostBack = false;
            //myList.ViewStateMode = ViewStateMode.Enabled;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn);
                    adapter.Fill(dbWeb2);
                    ViewState["Data"] = dbWeb2;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
            myList.AppendDataBoundItems = true;
            myList.DataSource = dbWeb2;
            myList.DataTextField = FieldName;
            myList.Items.Add(new ListItem("<None Selected>", string.Empty));
            if (dbWeb2.Tables.Count > 0)
            {
                myList.DataBind();
            }
            else
            {
                Label1.Text = "Error on the SQL Query" + cmdText;
                return cmdText;
            }
            myCheckBox.Text = FieldName;
            return cmdText;
        }
