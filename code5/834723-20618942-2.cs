    private void graph1_AxisViewChanged(object sender, ViewEventArgs e) {
      var index = Convert.ToInt32(graph1.Series[0].XValueMember);
      if (index < x_index) {
        graph1.Series.Clear();
        for (int i = index; i < index + 50; i++) {
          var pt = (Series)m_dataTable.Rows[i]["Data"];
          graph1.Series.Add(pt);
        }
      }
    }
