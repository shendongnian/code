    foreach (ListItem item in listOthers.Items)
    {
        if (item.Selected)
        {
            sum += Convert.ToInt32(item.Text);//text of selected checkbox
        }
    }
    lblSum.Text = sum.ToString();
