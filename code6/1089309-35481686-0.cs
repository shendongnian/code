    workbook.CreateVBAProject();
    workbook.CodeModule.Name = "DisplayAlertsOff";
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("Sub CloseBook()");
    sb.AppendLine("    Application.DisplayAlerts = False");
    sb.AppendLine("    ActiveWorkbook.Close");
    sb.AppendLine("    Application.DisplayAlerts = True");
    sb.AppendLine("End Sub");
    workbook.CodeModule.Code = sb.ToString();
