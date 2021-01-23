     protected void Button1_Click(object sender, EventArgs e)
        {
            if (!ddlcountry.SelectedItem.ToString().Equals(ddlcountry_Res.SelectedItem.ToString()))
            {
                Response.Write(@"<script language='javascript'>alert('Items do not match.');</script>");
            }
        }
