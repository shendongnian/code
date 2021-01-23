    DataTable dt = new DataTable();
    dt.Columns.Add("Questions");
    dt.Rows.Add(new String[] { "One" });
    dt.Rows.Add(new String[] { "Two" });
    dt.Rows.Add(new String[] { "Three" });
    dt.Rows.Add(new String[] { "Four" });
    dt.Rows.Add(new String[] { "Five" });
    String[] questions = dt.AsEnumerable().Select(x => x["Questions"].ToString()).ToArray();
