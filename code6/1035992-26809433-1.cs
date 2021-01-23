            if (!String.IsNullOrWhiteSpace(dateCategory))
            {
                dateCategory = dateCategory.ToLower();
                string strConnString = ConfigurationManager.ConnectionStrings["PrimaryDBConnection"].ConnectionString;
                // return DataSet From USP
                DataSet dashBoardDataSet = GetDataSQL(strConnString, gym, dateCategory, iso8601date, 0);
                
                if (dashBoardDataSet != null)
                {
                    int chartPanelCount = dashBoardDataSet.Tables[0].Rows.Count;
                    List<ChartPanel> chartTypeList = new List<ChartPanel>(); // list for all the panels
                    // first table describes the Chart Panels
                    int tableCount = 0;
                   
                    for (int chartPanelLoop = 0; chartPanelLoop < chartPanelCount; chartPanelLoop++)
                    { // for every panel
                        ChartPanel chartPanel = new ChartPanel();
                        chartPanel.name = dashBoardDataSet.Tables[0].Rows[chartPanelLoop][2].ToString();
                        // second table describes the following chart areas for the panel
                        DataRow[] areaTableRows = dashBoardDataSet.Tables[1].Select("charttype = " + (chartPanelLoop + 1).ToString());
                        int panelAreaCount = areaTableRows.Count(); 
                        List<ChartArea> chartAreaList = new List<ChartArea>();
                        for (int panelAreaLoop = 0; panelAreaLoop < panelAreaCount; panelAreaLoop++) 
                        { // for every area 
                            int areaTable = 1; 
                            ChartArea chartArea = new ChartArea();
                            chartArea.name = areaTableRows[panelAreaLoop][3].ToString(); // dashBoardDataSet.Tables[areaTable].Rows[panelAreaLoop][3].ToString();
                            DataColumnCollection columns = dashBoardDataSet.Tables[areaTable + tableCount + 1].Columns;
                            DataRowCollection rows = dashBoardDataSet.Tables[areaTable + tableCount + 1].Rows;
                            Google.DataTable.Net.Wrapper.DataTable gdt = new Google.DataTable.Net.Wrapper.DataTable();
                            List<ColumnDisplayMap> cMap = new List<ColumnDisplayMap>();
                            foreach (DataColumn col in columns)
                            {
                                string colName = col.ToString();
                                if (!colName.Contains("_display"))
                                {
                                    ColumnType type = ColumnType.Number;
                                    if (!col.IsNumeric()) type = ColumnType.String;
                                    gdt.AddColumn(new Column(type, col.ToString(), col.ToString()));
                                }else
	                            {
                                    ColumnDisplayMap cdm = new ColumnDisplayMap(){columnToFormat = col.Ordinal - 1, formatColumn = col.Ordinal};
                                    cMap.Add(cdm);
	                            }
                            }
                            foreach (DataRow row in rows)
                            {
                                var r = gdt.NewRow();
                                for (int cellItem = 0; cellItem < row.ItemArray.Count(); cellItem++)
                                {
                                    if (cMap.Any(c => c.columnToFormat.Equals(cellItem)))
                                    {
                                        r.AddCell(new Cell(row.ItemArray[cellItem], row.ItemArray[cellItem + 1].ToString()));
                                    }
                                    else if (cMap.Any(c => c.formatColumn.Equals(cellItem)))
                                    {
                                        // do nothing
                                    }
                                    else
                                    {
                                        r.AddCell(new Cell(row.ItemArray[cellItem], row.ItemArray[cellItem].ToString()));
                                    }
                                }
                                gdt.AddRow(r);
                            }
                            
                            chartArea.table = JsonConvert.DeserializeObject(gdt.GetJson());
                            chartAreaList.Add(chartArea);
                            //}
                            if (chartAreaList.Count() > 0) chartPanel.areas = chartAreaList; 
                            tableCount++;
                        }                            
                        if (chartPanel.areas != null && chartPanel.areas.Count() > 0) chartTypeList.Add(chartPanel);
                    }
                    return Ok(chartTypeList);
                }
                else { return NotFound(); }
            }
            else { return NotFound(); }
        }
