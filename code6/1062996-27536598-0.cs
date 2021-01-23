        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pk = GridView2.DataKeys[row.RowIndex].Values["Id"].ToString();
            TextBox ss = GridView2.Rows[row.RowIndex].Cells[3].FindControl("VyskaStavky") as TextBox;
            //ss.text have my requested value
        }
