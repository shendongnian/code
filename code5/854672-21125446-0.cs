    private void MdiForm_Closing(object sender, FormClosingEventArgs e) {
      if (m_closePrompt) {
        string ask = "Really Close this Application?";
        if (MessageBox.Show(ask, "Confirmation",  MessageBoxButtons.YesNo, MessageBoxIcon.Question, 0) != DialogResult.Yes) {
          e.Cancel = true;
        } else {
          m_closePrompt = false;
        }
      }
    }
