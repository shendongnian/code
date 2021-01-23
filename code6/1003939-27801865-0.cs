	[TestMethod]
	public void Change_3DPieChart_Color()
	{
		const string PIE_PATH = "c:chartSpace/c:chart/c:plotArea/c:pie3DChart/c:ser";
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var workbook = package.Workbook;
			var worksheet = workbook.Worksheets.Add("newsheet");
			//Some data
			worksheet.Cells["A12"].Value = "wer";
			worksheet.Cells["A13"].Value = "sdf";
			worksheet.Cells["A14"].Value = "wer";
			worksheet.Cells["A15"].Value = "ghgh";
			worksheet.Cells["B12"].Value = 53;
			worksheet.Cells["B13"].Value = 36;
			worksheet.Cells["B14"].Value = 43;
			worksheet.Cells["B15"].Value = 86;
			//Create the pie
			var pieChart = (ExcelPieChart) worksheet.Drawings.AddChart("piechart", eChartType.Pie3D);
			//Set top left corner to row 1 column 2
			pieChart.SetPosition(18, 0, 0, 0);
			pieChart.SetSize(350, 300);
			pieChart.Series.Add(ExcelCellBase.GetAddress(12, 2, 15, 2), ExcelCellBase.GetAddress(12, 1, 15, 1));
			pieChart.Legend.Position = eLegendPosition.Bottom;
			pieChart.Legend.Border.Fill.Color = Color.Green;
			pieChart.Legend.Border.LineStyle = eLineStyle.Solid;
			pieChart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
			pieChart.Title.Text = "Current Status";
			pieChart.DataLabel.ShowCategory = false;
			pieChart.DataLabel.ShowPercent = true;
			//Get the nodes
			var ws = pieChart.WorkSheet;
			var nsm = ws.Drawings.NameSpaceManager;
			var nschart = nsm.LookupNamespace("c");
			var nsa = nsm.LookupNamespace("a");
			var node = pieChart.ChartXml.SelectSingleNode(PIE_PATH, nsm);
			var doc = pieChart.ChartXml;
			//Add the node
			var rand = new Random();
			for (var i = 0; i < 4; i++)
			{
				//Create the data point node
				var dPt = doc.CreateElement("dPt", nschart);
				var idx = dPt.AppendChild(doc.CreateElement("idx", nschart));
				var valattrib = idx.Attributes.Append(doc.CreateAttribute("val"));
				valattrib.Value = i.ToString(CultureInfo.InvariantCulture);
				node.AppendChild(dPt);
				//Add the solid fill node
				var spPr = doc.CreateElement("spPr", nschart);
				var solidFill = spPr.AppendChild(doc.CreateElement("solidFill", nsa));
				var srgbClr = solidFill.AppendChild(doc.CreateElement("srgbClr", nsa));
				valattrib = srgbClr.Attributes.Append(doc.CreateAttribute("val"));
				//Set the color
				var color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
				valattrib.Value = ColorTranslator.ToHtml(color).Replace("#", String.Empty);
				dPt.AppendChild(spPr);
			}
			package.Save();
		}
	}
