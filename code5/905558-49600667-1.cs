    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        int comment_id = Convert.ToInt32(dataTable.Rows[i]["comment_id"]);
        string created_by_name = dataTable.Rows[i]["created_by_name"].ToString();
        string created_at = dataTable.Rows[i]["created_at"].ToString();
        string comment = dataTable.Rows[i]["comment"].ToString();
        HtmlGenericControl divComment = new HtmlGenericControl("div"); //This is root object of comment.Other objects like textbox,button,etc added into this object.
        //divComment.Attributes.Add("class", "div_post_display");
        divComment.Attributes.Add("id", comment_id.ToString());
        /* Comment by */
        HtmlGenericControl lblCommentBy = new HtmlGenericControl("label");
        //lblCommentBy.Attributes.Add("class", "divauthor");
        lblCommentBy.InnerText = "" + created_by_name + " (" + created_at + ")";
        /* Comment body */
        HtmlGenericControl pComment = new HtmlGenericControl("p");
        //lblCommentBy.Attributes.Add("class", "divauthor");
        pComment.InnerText = comment;
        divComment.Controls.Add(lblCommentBy);
        divComment.Controls.Add(pComment);
        if (Session["user_id"] != null)
        {
            if (Session["user_level"].ToString() == "1") //Admin can reply for comment
            {
                /* Reply Form */
                TextBox txtReply = new TextBox(); //Create object dynamacaly
                txtReply.ID = "txtReply_"+comment_id;
                txtReply.Attributes.Add("class", "form-control"); //Add css class
                txtReply.Width = 400;
                divComment.Controls.Add(txtReply); //Add obj to root object(div)
                Button btnReply = new Button(); //Create object dynamacaly
                btnReply.Text = "Reply"; //Set button text 
                btnReply.Attributes.Add("class", "btn btn-sm btn-success"); //Add css class
                btnReply.Click += btnReply_Click;
                btnReply.CommandArgument = comment_id.ToString();
                divComment.Controls.Add(btnReply); //Add obj to root object(div)
                HtmlGenericControl br = new HtmlGenericControl("br"); //Create object dynamacaly
                divComment.Controls.Add(br); //new line
            }
        }
        pnlShowComments.Controls.Add(divComment);
    }
