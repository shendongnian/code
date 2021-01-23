    private void btnACart_Click(object sender, EventArgs e)
    {
        int value = 0;
        for (int i = 0; i < lvCart.Items.Count; i++)
        {
            value += int.Parse(lvCart.Items[i].SubItems[1].Text);
        }
        _listTotal += value;
        rtbTcost.Text = _listTotal.ToString();
    }
