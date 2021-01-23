        protected void Chart1_CustomizeLegend(object sender, System.Web.UI.DataVisualization.Charting.CustomizeLegendEventArgs e)
        {
            if (e.LegendItems.Count > 0)
            {
                for (int i = 0; i < e.LegendItems.Count; i++)
                {
                    if (e.LegendItems[0].Cells.Count > 1)
                    {
                        e.LegendItems[i].Cells[1].Text = e.LegendItems[i].Cells[1].Text.Replace("RunTime - ", "").Replace(" 12:00 AM", "");
                    }
                }
            }
        }
