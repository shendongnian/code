    XRDesignRibbonForm designForm = new XRDesignRibbonForm();
    designForm.OpenReport(Your_Report_Object);
    XRDesignPanel panel = designForm.ActiveDesignPanel;
    designForm.ActiveDesignPanel.SetCommandVisibility(ReportCommand.SaveFileAs, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);
    designForm.ActiveDesignPanel.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
    designForm.ActiveDesignPanel.SetCommandVisibility(ReportCommand.ShowPreviewTab, CommandVisibility.None);
    designForm.ActiveDesignPanel.SetCommandVisibility(ReportCommand.ShowHTMLViewTab, CommandVisibility.None);
    designForm.ActiveDesignPanel.SetCommandVisibility(ReportCommand.ShowTabbedInterface, CommandVisibility.None);
    if (panel != null)
          panel.AddCommandHandler(new SaveCommandHandler(panel));
    designForm.ShowDialog();
