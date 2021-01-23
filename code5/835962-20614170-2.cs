    private void BuildPageNumbers()
    {
        ddlPageNumber.Items.Clear();
        for (int cnt = 0; cnt < GridView1.PageCount; cnt++)
        {
            int curr = cnt + 1;
            ListItem item = new ListItem(curr.ToString());
            if (cnt == GridView1.PageIndex)
            {
                item.Selected = true;
            }
            ddlPageNumber.Items.Add(item);
        }
    }
