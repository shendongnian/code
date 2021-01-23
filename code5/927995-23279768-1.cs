    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    using (SqlDataReader rd = command.ExecuteReader())
    {
        if (rd.HasRows)
        {
            while (rd.Read())
            {
                sb.Append(rd[0].ToString());
                sb.Append("<br />");
            }
        }
    }
    Row1.InnerHtml = sb.ToString();
