    var index = 0;
    foreach (ListItem item in listOthers.Items)
    {
        index++; // Increase here as the Textbox numbers start at 1
        if (item.Selected)
        {
            var txt = FindControl("TextBox" + index.ToString()) as TextBox;
            if (txt != null)
                sum += Convert.ToInt32(txt.Text);  //text of selected Checkbox
        }
    }
    lblSum.Text = sum.ToString();
