    foreach (Control x in this.Controls)
    {
      if (x is ComboBox)
      {
        foreach (var item in x.Items)
        {
            intCBSum += int.Parse(item.ToString());
            intCBCount++;
        }
      }
    }
