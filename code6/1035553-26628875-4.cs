    void hereAreAllThePeople()
    {
        if (con.dSet != null)
        {
            foreach (DataRow row in dSet.Tables[0].Rows)
        {
        		Officers.Add(string.Join("", row.ItemArray.Select(p => (p == null) ? "": p.ToString()).ToArray()));
        	}
            }
        }
