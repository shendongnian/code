            private void FormCrystalRepotViewer_Shown(object sender, EventArgs e)
        {
            ReportDocument crReport = crArrReport[0];
            crystalReportViewer.ReportSource = crReport;
            crystalReportViewer.Zoom(100);
            crystalReportViewer.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintToPrinter;
            tcTabControl.TabPages[0].Text = arrRaporlar.Get(0).sReportName;
            for (int i = 1; i < crArrReport.Count; i++)
            {
                crReport = crArrReport[i];
                CrystalDecisions.Windows.Forms.CrystalReportViewer crview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crview.ReportSource = crReport;
                crview.Zoom(100);
                crview.PrintMode = crystalReportViewer.PrintMode;
                crview.ActiveViewIndex = -1;
                crview.BorderStyle = crystalReportViewer.BorderStyle;
                crview.Cursor = crystalReportViewer.Cursor;
                crview.Dock = crystalReportViewer.Dock;
                crview.Location = crystalReportViewer.Location;
                crview.Size = crystalReportViewer.Size;
                crview.TabIndex = 0;
                crview.ToolPanelView = crystalReportViewer.ToolPanelView;
                crview.ShowParameterPanelButton = crystalReportViewer.ShowParameterPanelButton;
                crview.ShowLogo = crystalReportViewer.ShowLogo;
                crview.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalReportViewer_ReportRefresh);
                TabPage page = new TabPage(arrRaporlar.Get(i).sReportName);
                tcTabControl.TabPages.Add(page);
                page.Controls.Add(crview);
                page.AutoScroll = true;
            }
        }
            private void crystalReportViewer_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            e.Handled = true;
            ParametreleriKontrolEt();
            crystalReportViewer.ReportSource = crArrReport[0];
            for (int i = 1; i < crArrReport.Count; i++)
            {
                CrystalDecisions.Windows.Forms.CrystalReportViewer crview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crview = tcTabControl.TabPages[i].Controls[0] as CrystalDecisions.Windows.Forms.CrystalReportViewer;
                crview.ReportSource = crArrReport[i];
            }
        }
