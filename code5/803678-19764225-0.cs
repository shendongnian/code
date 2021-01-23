    for (int i = 1; i < 11; i++)
        {
            TextBox t1 = new TextBox();
            t1.ID = "TextBox" + i;
            ContentPlaceHolder cph = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolder1");
            cph.Controls.Add(t1);
        }
