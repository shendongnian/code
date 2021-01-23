        Button button = (sender as Button);
        string commandArgument = button.CommandArgument;
        RepeaterItem item = button.NamingContainer as RepeaterItem;
        var workText = (Label)item.FindControl("workName1") as Label;
        string work = workText.Text;
        string text = workDetails1.Text;
        if (text == "	")
            text = "";
        if (text == "")
        {
            if (!text.Contains(work))
            {
                text +="\u2022 " + work;
                workDetails1.Text = text;
            }
        }
        else if (!string.IsNullOrEmpty(work))
        {
            if (!text.Contains(work))
            {
                text += "\n\u2022 " + work;
                workDetails1.Text = text;
            }
            else
            {
                workDetails1.Text = text;
            }
        }
        UpdatePanel4.Update();
