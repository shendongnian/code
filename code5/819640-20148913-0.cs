    private void Form4_Load(object sender, EventArgs e)
    {
        con = new SqlConnection("data source=PC\\SQLEXPRESS;integrated security=true;Initial catalog=MyDB");
        BindData1();
    }
    public void BindData1()
    {
        DataTable dt = null;
        using (SqlConnection con =  new SqlConnection("data source=PC\\SQLEXPRESS;integrated security=true;Initial catalog=MyDB"))
        {
            con.Open();
            string strCmd = "select Items from tblbill";
            using (SqlCommand cmd = new SqlCommand(strCmd, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                dt = new DataTable("TName");
                da.Fill(dt);
            }
        }
        comboBox1.DisplayMember = "field1";
        comboBox1.ValueMember = "field2";
        comboBox1.DataSource = dt;
        textBox1.DataBindings.Add(new Binding("Text", dt, "field3"));
        }
    }
