      RadGrid1.MasterTableView.Controls.Add(new LiteralControl("<span><br/>Description: Data selected using dates between 1 Jan 2011 to 1 Sep 2011</span>"));
      RadGrid1.MasterTableView.Caption = "<span><br/>Exported by: John Smith</span>";
      RadGrid1.ExportSettings.OpenInNewWindow = true;
      RadGrid1.ExportSettings.ExportOnlyData = false;
      RadGrid1.MasterTableView.ExportToExcel();
