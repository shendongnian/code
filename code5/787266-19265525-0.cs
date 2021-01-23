    SqlDataAdapter da = new SqlDataAdapter("select ORG_NAME,USERS from SURVEY_ORG where USERS<>0", con);
                da.Fill(dataSet);
                Int32 totalArraySize = dataSet.Tables[0].Rows.Count;
                Object[] XAxisData = new object[totalArraySize];
                Object[] YAxisServices = new object[totalArraySize];
                int J = 0;
                foreach (DataRow drRow in dataSet.Tables[0].Rows)
                {
                    YAxisServices[J] = new object[] { drRow[0].ToString(), Convert.ToInt32(drRow[1].ToString()) };
                    J += 1;
                }
                Highchart.Core.SerieCollection series = new Highchart.Core.SerieCollection();
                Highchart.Core.Data.Chart.Serie serieServices = new Highchart.Core.Data.Chart.Serie();
                serieServices.size = 130;
                serieServices.data = YAxisServices;
                serieServices.type = RenderType.pie;
                serieServices.name = "";
                serieServices.showInLegend = false;
                series.Add(serieServices);
    
                chart1.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsPie
                {
                    allowPointSelect = true,
                    cursor = "pointer",
                    dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true, formatter = "this.point.name" },
                    animation = false
                };
                chart1.Tooltip = new ToolTip("this.point.name +': '+ this.y");
                chart1.DataSource = series;
                chart1.DataBind();
                chart1.Dispose();
