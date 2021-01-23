    StringBuilder sb = new StringBuilder();
    foreach (var item in SelectedNarrative)
    {
      sb.Append(item.Field<string>("narr_code"));
    }
    txtLine1.Text = sb.ToString();
