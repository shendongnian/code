        if (RadioButtonList1.SelectedIndex == -1)
        {
            SqlCommand sqlcmd1 = new SqlCommand("update TEST1 set Your_Answer=NULL where Question='1'", con);
            sqlcmd1.ExecuteScalar();
        }
        else
        {
            string rb1 = RadioButtonList1.SelectedItem.Text;
            SqlCommand cmd1 = new SqlCommand("update TEST1 set Your_Answer='" + rb1 + "' where Question='1'", con);
            cmd1.ExecuteScalar();
        }}
