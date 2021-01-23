	    // Create an XmlReader
        using (XmlReader reader = XmlReader.Create(new StringReader(results)))
        {
            ds.ReadXml(reader);
        }
            
        // Build DataTable
        StringBuilder sb = new StringBuilder();
        dt.Columns.Add("Date");
        dt.Columns.Add("PayCodeId");
        dt.Columns.Add("AmountInTime");
        DataTable dateTotals = ds.Tables["DateTotals"];
        DataTable totals = ds.Tables["Totals"];
        DataTable total = ds.Tables["Total"];
        foreach(DataRow dateTotalsRow in dateTotals.Rows)
        {
            if (dateTotalsRow.Field<string>("GrandTotal") == null || dateTotalsRow.Field<string>("GrandTotal") == "0.0")
            {
                DataRow dr;
                object[] rowItems = new object[dt.Columns.Count];
                rowItems[0] = dateTotalsRow.Field<string>("Date");
                rowItems[1] = "";
                rowItems[2] = "";
                dr = dt.NewRow();
                dr.ItemArray = rowItems;
                dt.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow totalsRow in totals.Rows)
                {
                    if (totalsRow.Field<int>("DateTotals_Id").ToString() == dateTotalsRow.Field<int>("DateTotals_Id").ToString())
                    {
                        foreach (DataRow totalRow in total.Rows)
                        {
                            if (totalRow.Field<int>("Totals_Id").ToString() == totalsRow.Field<int>("Totals_Id").ToString())
                            {
                                DataRow dr;
                                object[] rowItems = new object[dt.Columns.Count];
                                rowItems[0] = dateTotalsRow.Field<string>("Date");
                                rowItems[1] = totalRow.Field<string>("PayCodeId");
                                rowItems[2] = totalRow.Field<string>("AmountInTime");
                                dr = dt.NewRow();
                                dr.ItemArray = rowItems;
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
        }
        return dt;
