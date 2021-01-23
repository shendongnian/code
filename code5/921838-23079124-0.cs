    private void WriteToGuiManyTimesButton_Click(object sender, EventArgs e) {
      DateTime startTime = DateTime.Now;
    
      StringBuilder Sb = new StringBuilder();
    
      for (int i = 0; i < numberOfIterations; ++i) {
        Sb.Append("s");
      }
    
      TestTextBox.Text = Sb.ToString();
    
      DateTime endTime = DateTime.Now;
      TestLabel.Text = (endTime.Ticks - startTime.Ticks).ToString();
    }
