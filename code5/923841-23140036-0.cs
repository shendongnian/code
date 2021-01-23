    foreach (GridViewRow gvr in GridView2.Rows)
    {
        if (gvr == row2)
        {
            string1 = Convert.ToInt32(gvr.Cells[0].Text);
            Label1.Text = string1.ToString();
            break;
        }
        else 
        {
            Label1.Text = "no";
        }
    }
