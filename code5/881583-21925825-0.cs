        SqlCommand cmd = new SqlCommand("Select img from tbImage where id = " + id+"", con);
        con.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                byte[] img = (byte[])dr["img"];
                string base64string = Convert.ToBase64String(img, 0, img.Length);
                lblImage.Text += "<img src='data:image/png;base64," + base64string + "' alt='No Image' width='200px' vspace='5px' hspace='5px' />";
            }
        }
        con.Close();
