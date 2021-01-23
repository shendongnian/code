	public static void SetSeriesStyle(this ExcelLineChart chart, ExcelChartSerie series, Color color, decimal? thickness = null) {
		if (thickness < 0) throw new ArgumentOutOfRangeException("thickness");
		var i = 0;
		var found = false;
		foreach (var s in chart.Series) {
			if (s == series) {
				found = true;
				break;
			}
			++i;
		}
		if (!found) throw new InvalidOperationException("series not found.");
		//Get the nodes
		var nsm = chart.WorkSheet.Drawings.NameSpaceManager;
		var nschart = nsm.LookupNamespace("c");
		var nsa = nsm.LookupNamespace("a");
		var node = chart.ChartXml.SelectSingleNode(@"c:chartSpace/c:chart/c:plotArea/c:lineChart/c:ser[c:idx[@val='" + i.ToString(CultureInfo.InvariantCulture) + "']]", nsm);
		var doc = chart.ChartXml;
		//Add the solid fill node
		var spPr = doc.CreateElement("c:spPr", nschart);
		var ln = spPr.AppendChild(doc.CreateElement("a:ln", nsa));
		if (thickness.HasValue) {
			var w = ln.Attributes.Append(doc.CreateAttribute("w"));
			w.Value = Math.Round(thickness.Value * 12700).ToString(CultureInfo.InvariantCulture);
			var cap = ln.Attributes.Append(doc.CreateAttribute("cap"));
			cap.Value = "rnd";
		}
		var solidFill = ln.AppendChild(doc.CreateElement("a:solidFill", nsa));
		var srgbClr = solidFill.AppendChild(doc.CreateElement("a:srgbClr", nsa));
		var valattrib = srgbClr.Attributes.Append(doc.CreateAttribute("val"));
		//Set the color
		valattrib.Value = color.ToHex().Substring(1);
		node.AppendChild(spPr);
	}
	public static void SetDataPointStyle(this ExcelPieChart chart, int dataPointIndex, Color color) {
		//Get the nodes
		var nsm = chart.WorkSheet.Drawings.NameSpaceManager;
		var nschart = nsm.LookupNamespace("c");
		var nsa = nsm.LookupNamespace("a");
		var node = chart.ChartXml.SelectSingleNode("c:chartSpace/c:chart/c:plotArea/c:lineChart/c:ser", nsm);
		var doc = chart.ChartXml;
		//Add the node
		//Create the data point node
		var dPt = doc.CreateElement("c:dPt", nschart);
		var idx = dPt.AppendChild(doc.CreateElement("c:idx", nschart));
		var valattrib = idx.Attributes.Append(doc.CreateAttribute("val"));
		valattrib.Value = dataPointIndex.ToString(CultureInfo.InvariantCulture);
		node.AppendChild(dPt);
		//Add the solid fill node
		var spPr = doc.CreateElement("c:spPr", nschart);
		var solidFill = spPr.AppendChild(doc.CreateElement("a:solidFill", nsa));
		var srgbClr = solidFill.AppendChild(doc.CreateElement("a:srgbClr", nsa));
		valattrib = srgbClr.Attributes.Append(doc.CreateAttribute("val"));
		//Set the color
		valattrib.Value = color.ToHex().Substring(1);
		dPt.AppendChild(spPr);
	}
    public static String ToHex(this Color c) {
        return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    }
