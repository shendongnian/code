    using (RichTextBox tmpRB = new RichTextBox()) {
      tmpRB.SelectAll();
      tmpRB.SelectedRtf = rtb.SelectedRtf;
      for (int i = 0; i < tmpRB.TextLength; ++i) {
        tmpRB.Select(i, 1);
        tmpRB.SelectionFont = new Font("Arial", tmpRB.SelectionFont.Size);
      }
      tmpRB.SelectAll();
      rtb.SelectedRtf = tmpRB.SelectedRtf;
    }
