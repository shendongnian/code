    if (Page.IsPostBack || !Page.IsPostBack)
                {
                    foreach (GridViewRow allrows in gvPosts.Rows)
                    {
                        string messageid = ((Label)allrows.FindControl("lblMessageID")).Text;
                        Image image = ((Image)allrows.FindControl("postImage"));
                    conn.Open();
                    SqlCommand checkNullImage = new SqlCommand("SELECT Image FROM BlogMessages WHERE MessageID=" + messageid, conn);
                    nullImage = Convert.ToString(checkNullImage.ExecuteScalar());
                    if (nullImage == DBNull.Value.ToString())
                    {
                        image.Visible = false;
                    }
                    conn.Close();
                }
