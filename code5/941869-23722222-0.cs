            Button b = new Button();
            b.Text = li.Text;
            b.ID = "ctl" + i;
            b.PostBackUrl = "StartUpPage.aspx?id=" + b.ID;          
            PlaceHolderButtons.Controls.Add(b);
            i++;
        }`
