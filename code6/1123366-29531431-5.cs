    private void PivotGridControl_DataSourceChanged(object sender, RoutedEventArgs e)
    {
        var pivotTable = sender as PivotGridControl;
        pivotTable.Groups.Clear();
        pivotTable.RetrieveFields();
    }
    private void PivotGridControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
        if (e.MenuType != PivotGridMenuType.Header)
            return;
        var fieldHeader = e.TargetElement as FieldHeader;
        if (fieldHeader == null)
            return;
        var field = fieldHeader.Content as PivotGridField;
        if (field == null || (field.Group != null && field.Group.IndexOf(field) > 0))
            return;
        var groupInterval = field.GroupInterval;
        if (groupInterval == FieldGroupInterval.Default && field.DataType != typeof(DateTime))
            return;
        var dateTimeIntervals = new List<FieldGroupInterval>(new FieldGroupInterval[]
        {
            FieldGroupInterval.DateYear,
            FieldGroupInterval.DateQuarter,
            FieldGroupInterval.DateMonth,
            FieldGroupInterval.DateDay,
            FieldGroupInterval.Hour,
            FieldGroupInterval.Minute,
            FieldGroupInterval.Second,
            FieldGroupInterval.DateWeekOfYear,
            FieldGroupInterval.DateWeekOfMonth,
            FieldGroupInterval.DateDayOfYear,
            FieldGroupInterval.DateDayOfWeek,
            FieldGroupInterval.Date,
            FieldGroupInterval.Default
        });
        if (!dateTimeIntervals.Contains(groupInterval))
            return;
        var pivotTable = sender as PivotGridControl;
        var subMenu = new BarSubItem() { };
        subMenu.Content = "Set group interval";
        if (field.Group == null)
        {
            var button = new BarButtonItem() { Content = "Year - Month - Date" };
            button.ItemClick += (s, eventArgs) =>
            {
                pivotTable.BeginUpdate();
                var group = field.Tag as PivotGridGroup;
                if (group == null)
                {
                    if (groupInterval != FieldGroupInterval.Default)
                        field.Caption = field.Caption.Replace(" (" + groupInterval + ")", string.Empty);
                    group = new PivotGridGroup();
                    group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (year)", GroupInterval = FieldGroupInterval.DateYear, Tag = field, Area = field.Area, AreaIndex = field.AreaIndex });
                    group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (month)", GroupInterval = FieldGroupInterval.DateMonth });
                    group.Add(new PivotGridField() { FieldName = field.FieldName, Caption = field.Caption + " (day)", GroupInterval = FieldGroupInterval.DateDay });
                    foreach (var groupField in group)
                        pivotTable.Fields.Add(groupField);
                    pivotTable.Groups.Add(group);
                    group.Tag = field;
                }
                else
                {
                    var yearField = group[0];
                    yearField.Area = field.Area;
                    yearField.AreaIndex = field.AreaIndex;
                    yearField.ShowInCustomizationForm = true;
                }
                field.Visible = false;
                field.ShowInCustomizationForm = false;
                pivotTable.EndUpdate();
            };
            subMenu.Items.Add(button);
        }
        foreach (var dateTimeInterval in dateTimeIntervals.Where(item => item != groupInterval))
        {
            var button = new BarButtonItem() { Content = dateTimeInterval, Tag = field };
            subMenu.Items.Add(button);
            button.ItemClick += (s, eventArgs) =>
            {
                pivotTable.BeginUpdate();
                var group = field.Group;
                if (group != null)
                {
                    var yearField = field;
                    field = yearField.Tag as PivotGridField;
                    field.Area = yearField.Area;
                    field.AreaIndex = yearField.AreaIndex;
                    field.ShowInCustomizationForm = true;
                    yearField.Visible = false;
                    yearField.ShowInCustomizationForm = false;
                }
                else if (groupInterval != FieldGroupInterval.Default)
                    field.Caption = field.Caption.Replace(" (" + groupInterval + ")", string.Empty);
                field.GroupInterval = dateTimeInterval;
                if (dateTimeInterval != FieldGroupInterval.Default)
                    field.Caption += " (" + dateTimeInterval + ")";
                pivotTable.EndUpdate();
            };
        }
        e.Customizations.Add(subMenu);
    }
