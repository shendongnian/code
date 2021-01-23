    protected void gvPosts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPosts.EditIndex = -1;
            //used the same DataBound()
        }
