    private void ShowForm2(string optionalText) {
      if (m_form2 == null) {
        m_form2 = new Form2();
        m_form2.Show();
      } else {
        m_form2.Focus();
      }
      if (!String.IsNullOrEmpty(optionalText)) {
        m_form2.Text = optionalText;
      }
    }
