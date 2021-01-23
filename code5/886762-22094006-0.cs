    DataTable aggregatedTable = new DataTable();
                foreach (SPListItem item in items)
                {
                    string url = item["SiteUrl"].ToString();
    
                    using (SPSite siteadd = new SPSite(url))
                    using (SPWeb webadd = siteadd.OpenWeb())
                    {
                        //
                        DataGrid grd = null;
                        grd = new DataGrid();
    
                        DataTable table = webadd.GetUsageData(Microsoft.SharePoint.Administration.SPUsageReportType.browser, Microsoft.SharePoint.Administration.SPUsagePeriodType.lastMonth);
                        if (table == null)
                        {
                            //  HttpContext.Current.Response.Write("Table Null");
                        }
                        else
                        {
                            aggregatedTable.Merge(table);//Append the data to previous site data.
                        }
                    }
                }
                dataGridView1.DataSource = aggregatedTable;//bind datatable with aggregated data
