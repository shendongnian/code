     protected void imgbtn_Click(object sender, ImageClickEventArgs e)
     {
                Session["Id"] = Convert.ToInt32((sender as ImageButton).CommandArgument);
                // show panel here
     }
