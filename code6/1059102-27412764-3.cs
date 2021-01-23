    protected void Button1_Click(object sender, EventArgs e)
    {
        ID = TextBox1.Text;
        dataclass dc = Getdata(ID);
        if (dc != null)
        {
            // Do something with dc.idd, dc.datetime, dc.col1, dc.col2, dc.col3
        }
    }
    public static dataclass Getdata(string ID)
    {
        string connStr = ConfigurationManager.ConnectionStrings["jsonobject"].ConnectionString;
        string cmdStr = "SELECT ([idd],[datetime],[col1],[col2],[col3]) FROM [jsondata] WHERE [idd]=@idd;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@idd", ID);
                using (SqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        dataclass dc = new dataclass();
                        dc.idd = Convert.ToString(myReader["idd"]);
                        dc.datetime = Convert.ToString(myReader["datetime"]);
                        dc.col1 = Convert.ToString(myReader["col1"]);
                        dc.col2 = Convert.ToString(myReader["col2"]);
                        dc.col3 = Convert.ToString(myReader["col3"]);
                        return dc;
                    }
                }
            }
        }
        return null;
    }
