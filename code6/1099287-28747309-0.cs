    gridSettings.SettingsExport.RenderBrick = (sender, e) =>
                {
                    foreach (MVCxPivotGridField item in dataFields)
                    {
                        if (e.RowType == DevExpress.Web.ASPxGridView.GridViewRowType.Data
                            && !string.IsNullOrEmpty(item.CellFormat.FormatString))
                            e.TextValueFormatString = item.CellFormat.FormatString;
                    }
