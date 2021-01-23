    Label l = new Label
    {
      Text = filter.Caption,
      AssociatedControlID = string.Format("{0}{1}", filter.ID, filter.ReportID)
    };
    column.Controls.Add(l);
