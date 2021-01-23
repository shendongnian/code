    if (checkbox1.Checked && !checkbox2.Checked)
        {
          button1.Enable = true
        }
        else if (!checkbox1.Checked && checkbox2.Checked)
        {
          button1.Enable = false
        }
