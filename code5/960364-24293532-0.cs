    if (c is TextBox || c is ComboBox)
    {
          if (string.IsNullOrWhiteSpace(c.Text))
          {
                MessageBox.Show(string.Format("Empty field {0 }", c.Name.Substring(3)));
                c.Focus();
                return false;
          }
    }
    else if(c is RadioButton)
    {
          // Logic
    }
    else if(c is CheckBox)
    {
          // Logic
    }
