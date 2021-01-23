    if (e.CommandName == "Post")
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            HiddenField hfproductid = (HiddenField)item .FindControl("hfproductID");
            HiddenField hfshareID = (HiddenField)item.FindControl("hfshareID");
    
            LinkButton post = (LinkButton)item.FindControl("Post");
            comobj._CommentID = Guid.NewGuid();
            comobj._ShareID = new Guid(hfshareID.Value.ToString());
            comobj._ClientID = new Guid(hfClientID.Value.ToString());
    
            TextBox txtcomment = (TextBox)e.Item.FindControl("txtcomment");
            comobj._Body = txtcomment.Text;
    
            comobj.SaveComment();
            post.Enabled = false;
            post.Text = "Posted";
        }
    }
