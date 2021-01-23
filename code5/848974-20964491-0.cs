    int UserId = Convert.ToInt32(Session["User"]);
    int[] OthersPosts = (from s in Data.Follow where s.FollowedBy == UserId) select s.Following1).ToArray();
    foreach (int post in OthersPosts)
    {
        var DisplayPost = (from s in Data.Posts where s.PostID == post && s.UserID == UserId) select s).ToList();
        ListViewPostTable.DataSourceID = "";
        ListViewPostTable.DataSource = DisplayPost;
        ListViewPostTable.DataBind();
    }
