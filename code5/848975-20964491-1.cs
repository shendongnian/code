    int UserId = Convert.ToInt32(Session["User"]);
    int[] OthersPosts = (from s in Data.Follow where s.FollowedBy == UserId) select s.Following1).ToArray();
    List<Posts> lstPosts = new List<Posts>();
    foreach (int post in OthersPosts)
    {
        var displayPost = (from s in Data.Posts where s.UserID == post) select s).ToList();
        lstPosts.AddRange(displayPost);
    }
    ListViewPostTable.DataSourceID = "";
    ListViewPostTable.DataSource = lstPosts;
    ListViewPostTable.DataBind();
