    protected void Btn2_Click(object sender, EventArgs e)
    {
        List<ListItem> itemList = new List<ListItem>();
        if (LB1.SelectedIndex >= 0)
        {
            for (int i = 0; i < LB1.Items.Count; i++)
            {
                if (LB1.Items[i].Selected)
                {
                    if (!itemList.Contains(LB1.Items[i]))
                    {
                        itemList.Add(LB1.Items[i]);
                    }
                }
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                if (!LB2.Items.Contains(itemList[i]))
                {
                    LB2.Items.Add(itemList[i]);
                }
                LB1.Items.Remove(itemList[i]);
            }
            LB2.SelectedIndex = -1;
        }
    }
