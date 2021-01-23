    foreach (Control control in panel1.Controls)
    {
      if (control is CheckBox)
      {
        if ((control as CheckBox).Checked)
        {
          ...
        }
      }
    }
