    public void PreviewReport() 
    {
        ReportDocument tempCover = new ReportDocument();
        tempCover.Load(@"test.rpt");
        using (Form form = new Form()) 
        {
            writeLog("new form");
            CrystalReportViewer tempViewer = new CrystalReportViewer();
            tempViewer.ActiveViewIndex = -1;
            tempViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tempViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            tempViewer.Name = "tempViewer";
            tempViewer.SelectionFormula = "";
            tempViewer.TabIndex = 0;
            tempViewer.ViewTimeSelectionFormula = "";
            
            tempViewer.ReportSource = tempCover;
            writeLog(Convert.ToString(tempViewer.ReportSource));
            tempViewer.AutoSize = true;
            tempViewer.Refresh();
            form.Controls.Add(tempViewer);
            form.AutoSize = true;
            form.ShowDialog();
        }
    }
