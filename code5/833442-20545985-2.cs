    TextBox box26 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("TextBox23");
    TextBox box18 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("TextBox19");
    TextBox box10 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox15");
    TextBox box27 = (TextBox)GridView1.FooterRow.Cells[7].FindControl("TextBox24");
    box26.Text = (Convert.ToDecimal(box18.Text) * Convert.ToDecimal(box10.Text)).ToString();
    if (c != null)
    {
        box27.Text = (Convert.ToDecimal(box27.Text) + Convert.ToDecimal(box26.Text)).ToString();
        c = Convert.ToDecimal(box27.Text);
    }
    else
    {
        c = 0.00M;
    }
