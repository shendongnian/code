    private void creatable()
    {
       dt.Columns.Add("FName");
       dt.Columns.Add("LName");
       dt.Columns.Add("Tag1");
       dt.Columns.Add("Tag2");
       dt.Columns.Add("Tag3");
       dt.Columns.Add("Tag_All");
    }
    private void removeColumn()
    {
            string temp = null;
            List<string> colToRemove = new List<string>();
            int colcount = dt.Columns.Count;
            for (int i = 0; i <colcount ;i++ )
            {
                temp = dt.Columns[i].ColumnName;
                if (temp == "Tag1" || temp == "Tag2" || temp == "Tag3")
                {
                    colToRemove.Add(temp);
                }
                temp = null;
            }
            foreach (string item in colToRemove)
            {
                dt.Columns.Remove(item);
            }
        }
