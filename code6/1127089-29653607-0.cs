    //...
    if (txtModifieddate.Text == null || txtModifieddate.Text == string.Empty)
    {
        cmd1.Parameters.Add("@modified_date", SqlDbType.DateTime).Value = DBNull.Value;
    }
    else
    {
        cmd1.Parameters.Add("@modified_date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtModifieddate.Text);
    }
    //...
