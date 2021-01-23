    private void chart1_FormatNumber(object sender, System.Windows.Forms.DataVisualization.Charting.FormatNumberEventArgs e)
    {
    	if(e.ElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.AxisLabels)
    	{
    		switch(e.Format)
    		{
    			case "MyAxisXCustomFormat":
    				e.LocalizedValue = DateTime.ParseExact(e.Value.ToString(), "yyyyMMdd", null).ToString("dd-MM");
    				break;
    			case "MyAxisYCustomFormat":
    				e.LocalizedValue = e.Value.ToString("#,###", _numberFormatInfoNLV);
    				break;
    			default:
    				break;
    		}
    	}
    }
