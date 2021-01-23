	private void button_Export_Click(object sender, EventArgs e)
	{
            
            var y = new DevExpress.XtraPrinting.PrintableComponentLink(new PrintingSystem());
            y.Component = gridControl1;
            y.CreateReportHeaderArea += y_CreateReportHeaderArea;
			if (saveFileDialog_Report.ShowDialog() == DialogResult.OK)
			{
				if (saveFileDialog_Report.FileName.ToLower().EndsWith("xlsx"))
				{
                    y.ExportToXlsx(saveFileDialog_Report.FileName);
				}				
			}	
	}
    void y_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
    {
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString("My Report Title Here", Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
    }
