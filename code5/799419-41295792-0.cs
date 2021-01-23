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
