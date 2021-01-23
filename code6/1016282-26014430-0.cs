     if(!IsPostback)
     {
                mydrop.DataSource = function();
                mydrop.DataTextField = "test";
                mydrop.DataValueField = "type";
                mydrop.DataBind();
                mydrop.SelectedIndex = 0;
                string[] a = new string[] { test.SelectedItem.Text, test2.Text,};
                Session["dataForm"] = a;
     }
                Response.Redirect("~/mypage.aspx");
