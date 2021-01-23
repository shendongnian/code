     TestDataGrid.AutoGeneratingColumn += (s, e) =>
                         {
                           if (e.Column.Header.ToString() == "YourColumnName")
                             e.Column.Width = new DataGridLength(1,
                                               DataGridLengthUnitType.
                                                 Star);
                         };
