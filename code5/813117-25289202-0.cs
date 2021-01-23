        // Add column
        settings.Columns.Add(column =>
        {
            column.FieldName = "FullName";
            column.Caption = "Full Name";
            column.UnboundType = DevExpress.Data.UnboundColumnType.String;
        });
        // Add the combined values to the column
        settings.CustomUnboundColumnData = (sender, e) =>
        {
            if (e.Column.FieldName == "FullName")
            {
                string fName = (string)e.GetListSourceFieldValue("FirstName");
                string lName = (string)e.GetListSourceFieldValue("LastName");
                e.Value = string.Format("{0} {1}", fName, lName);
            }
        };
