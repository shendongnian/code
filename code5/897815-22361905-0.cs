    string vote;
     
    //Your connection string. You don't want to open and close within the foreach because it will open and close for each row. Not ideal
    conn.Open();
    foreach(GridViewRow gvr in GridView1.Rows)
    {
        //you'll want to find the buttons
        Button voteUp = ((Button)gvr.FindControl("Btn_thumbs_up"));
        Button voteDown = ((Button)gvr.FindControl("Btn_thumbs_down"));
        Label SwotItemID = ((Label)gvr.FindControl("SwotItemID));//I would add SwotItemID as a templatefield with an asp label in it in your gridview
        SqlCommand cmdSelectVote= new SqlCommand("SELECT ThumpUpColumn FROM tLoveOrHateTable WHERE SwotItemID = '" + SwotItemID + "'", conn);
        vote = Convert.ToString(cmdSelectVote.ExecuteScalar());
           
        if(vote == "0")
        {
           voteDown.Enabled = false;
        }
        else if (vote == "1")
        {
           voteUp.Enabled = true;
        }
    }
    conn.Close();
