    var columns = new StringBuilder();
    var values = new StringBuilder();
    for (int i = 0; i < reader.VisibleFieldCount; i++) {
        values.Append("@").Append(i).Append(", ");
        columns.Append("[").Append(reader.GetName(i)).Append("], ");
    }
    values.Length -= 2;    // Remove last ", "
    columns.Length -= 2;
    string insert = String.Format("INSERT INTO myTable ({0}) VALUES ({1})",
                                  columns.ToString(), values.ToString());
