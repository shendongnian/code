    private void GetData(string channel, int scanStart, int step, int scanEnd) {
      m_dataTable = new DataTable();
      var col1 = m_dataTable.Columns.Add("Index", typeof(int));
      var col2 = m_dataTable.Columns.Add("Data", typeof(Series));
      for (var i = scanStart; i + step <= scanEnd; i += step) {
        var sample = _expeData.ReadSample(channel, i);
        var row = m_dataTable.NewRow();
        row[col1] = i;
        row[col2] = new Series(sample);
        m_dataTable.Rows.Add(row);
      }
    }
