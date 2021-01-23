    if (dsStudent.Tables[1].Rows.Count >= 2)
    {
        if (DBNull.Value.Equals(dsStudent.Tables[1].Rows[0][1])) //girls = 0
        {
        }
        if (DBNull.Value.Equals(dsStudent.Tables[1].Rows[1][1])) //boys = 0
        {
        }
    }
