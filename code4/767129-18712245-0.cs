    if (cb_odjezd.Text== string.Empty)
    {
        prikaz.Parameters.AddWithValue("@odjezd", DBNull.Value);
    }
    else
    {
        prikaz.Parameters.AddWithValue("@odjezd", cb_odjezd.Text);
    }
