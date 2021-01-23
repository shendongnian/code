     catch (FormatException err)
     {
        MessageBox.Show("Pay Rate must be numeric. " + err.Message,
                        "Data Entry Error", MessageBoxButtons.OK,;
                        MessageBoxIcon.Exclamation);
        txtPayRate.SelectAll();
        txtPayRate.Focus();
      }
