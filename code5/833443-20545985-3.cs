    TextBox box24 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("TextBox21");
            TextBox box16 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("TextBox17");
            TextBox box8 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox13");
    
            TextBox box25 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("TextBox23"); // Second Control of Amount Column
            TextBox box26 = (TextBox)GridView1.Rows[i].Cells[7].FindControl("TextBox24"); // Third Control of Amount Column
    
            TextBox box17 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("TextBox18"); // Second control of Rate Column
            TextBox box9 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox14"); // Second control of Order quantity Column
    
            TextBox box18 = (TextBox)GridView1.Rows[i].Cells[5].FindControl("TextBox19"); // Third control of Rate Column
            TextBox box10 = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox15"); // Third control of Order quantity Column
    
            TextBox box27 = (TextBox)GridView1.FooterRow.Cells[7].FindControl("TextBox24");
    
            box24.Text = (Convert.ToDecimal(box16.Text) * Convert.ToDecimal(box8.Text)).ToString();
            box25.Text = (Convert.ToDecimal(box17.Text) * Convert.ToDecimal(box9.Text)).ToString();
            box26.Text = (Convert.ToDecimal(box18.Text) * Convert.ToDecimal(box10.Text)).ToString();
    
            if (a != null)
            {
                box27.Text = (a + Convert.ToDecimal(box24.Text) + Convert.ToDecimal(box25.Text) + Convert.ToDecimal(box26.Text)).ToString();
                a = Convert.ToDecimal(box27.Text);
            }
            else
            {
                a = 0.00M;
            }
