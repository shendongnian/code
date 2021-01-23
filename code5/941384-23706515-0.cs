        conn.Open();
        string checkuser = "select count(*) from UserDataT where Username='" + TextBoxUSERNAME.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select password from UserDataT where Username='" + TextBoxUSERNAME.Text + "'";
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            string password = passComm.ExecuteScalar().ToString().Replace(" "," ");
            if (password == TextBoxPASSWORD.Text)
            { 
                Session["New"]= TextBoxUSERNAME.Text;
                Response.Write("Passwordi eshte korrekt.");
            }
            else
            {
                Response.Write("Passwordi nuk eshte korrekt.");
            }
            conn.Close();
        }
        else
        {
         Response.Write("Username nuk eshte korrekt.");
        }
