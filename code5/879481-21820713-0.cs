    protected void Btn2_Click(object sender, EventArgs e)
    {
        string sel = LB1.SelectedValue;
        List<string> ab = new List<string>();
        ab.Add(sel);
        L2.Text = Convert.ToString(ab.Count);
        for(int i =0; i < ab.Count ; i++)
        {
            string c = ab[i];
            LB2.Items.Add(c);
        }
       LB1.Items.Remove(LB1.SelectedValue);//Add This to remove selected item from ListBox1
    }
