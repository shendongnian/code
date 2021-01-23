    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("create table Employee (empno int,empname varchar(50),salary money);", cn);
            cmd.ExecuteNonQuery();
            lblAlert.Text = "SucessFully Connected";
            cn.Close();
        }
        catch (Exception eq)
        {
            lblAlert.Text = eq.ToString();
        }
    }
