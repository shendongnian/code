    <b>  Hope this will Help you </b>
           DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Phase", typeof(string));
            dtTemp.Columns.Add("Status", typeof(string));
            dtTemp.Columns.Add("Count", typeof(int));
            dtTemp.Columns.Add("StackGroupName", typeof(string));
            dtTemp.Rows.Add("Initiate", "Pending", 10, "Group1");
            dtTemp.Rows.Add("Initiate", "OnHold", 20, "Group1");
            dtTemp.Rows.Add("Initiate", "Rejected", 3, "Group1");
            dtTemp.Rows.Add("Initiate", "Cancelled", 5, "Group1");
            dtTemp.Rows.Add("Initiate", "PendingIT", 2, "Group1");
            dtTemp.Rows.Add("Setup", "Setup", 25, "Group2");
            dtTemp.Rows.Add("Setup", "INSTALLED", 55, "Group2");
            dtTemp.AcceptChanges();
      
      Series ss;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                ss = new Series();
                ss.Name = dtTemp.Rows[i][1].ToString();
                ss.ChartType = SeriesChartType.StackedColumn;
                ss["StackedGroupName"] = dtTemp.Rows[i]["StackGroupName"].ToString();
                ss["DrawingStyle"] = "Cylinder";
                
                ss.Points.AddXY(Convert.ToString(dtTemp.Rows[i]["Phase"]), Convert.ToInt32(dtTemp.Rows[i]["Count"]));
                ss.IsValueShownAsLabel = true;                
                ChartSideBySideStacked.Series.Add(ss);
            }
            ChartArea chartAread = new ChartArea();
            chartAread.Area3DStyle.Enable3D = true;
            chartAread.Area3DStyle.Rotation = 5;
            chartAread.Area3DStyle.Inclination = 10;
            chartAread.Area3DStyle.IsRightAngleAxes = false;
            ChartSideBySideStacked.ChartAreas.Add(chartAread);
            ChartSideBySideStacked.Legends.Add(new Legend("CHartLEgend"));
            ChartSideBySideStacked.AlignDataPointsByAxisLabel(); // Chart Object Name : ChartSideBySideStacked
