    protected void myGridview_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i <= myGridview.Rows.Count - 1; i++)
        {
            string myClassVal = myGridview.Rows[i].Cells[2].Text;
            if (myClassVal == "Class A")
            {
                myGridview.Rows[i].Cells[2].BackColor = Color.Green;
             }
            else if (myClassVal == "Class B")
            {
                myGridview.Rows[i].Cells[2].BackColor = Color.Red;
            }
            else 
            {
               myGridview.Rows[i].Cells[2].BackColor = Color.Orange;
            }
        }
    }
