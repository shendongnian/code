    foreach (Control c in this.Controls)
    {
       if (c is TextBox)
          if (String.IsNullOrEmpty(((TextBox)c).Text))
             ((TextBox)c).Background = Brushes.Blue; // Setting the background-color of the empty TextBoxes
    }
