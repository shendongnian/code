     protected void gridReports_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
            {
                if (e.Column.FieldName == "AMOUNT")
                {
                    object currency = e.GetFieldValue("DEFAULT_CURRENCY");
                    object amount = e.GetFieldValue("AMOUNT");
                    e.DisplayText = ((string)GTYPE(currency.ToString()) + amount);
                    
                }
            }
