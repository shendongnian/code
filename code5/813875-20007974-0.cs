      DataTable myData = new DataTable();
      DataColumn seqCol = new DataColumn("Seq", typeof (int));
      DataColumn maxLenCol = new DataColumn("MaxLen", typeof (int));
      myData.Columns.Add(seqCol);
      myData.Columns.Add(maxLenCol);
      while (reader.Read())
      {
        var row = myData.NewRow();
        bool addRow = false;
        int seq;
        if (int.TryParse(reader["Seq"].ToString(), out seq))
          if (seq > 30)
          {
            row[seqCol] = seq;
            addRow = true;
          }
        int maxlen;
        if (int.TryParse(reader["MaxLen"].ToString(), out maxlen))
          if (maxlen > 30.00)
          {
            row[maxLenCol] = maxlen;
            addRow = true;
          }
        if (addRow)
        {
          myData.Rows.Add(row);
        }
      }
