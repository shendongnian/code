    StringBuilder text = new StringBuilder();
    
    foreach (Control item in Controls)
     {
          if (item is TextBox)
            {
               text.Append(item.Text);
               text.Append(',');
            }
     }
    
    Clipboard.SetText(text.ToString());
