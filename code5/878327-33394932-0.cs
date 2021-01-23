    excelDoc.Workbook.CreateVBAProject();
    
    StringBuilder vbaCode = new StringBuilder();
    
    vbaCode.AppendLine("Private Sub Workbook_Open()");
    vbaCode.AppendLine("    Application.DisplayFormulaBar = False");
    vbaCode.AppendLine("End Sub");
    
    excelDoc.Workbook.CodeModule.Code = vbaCode.ToString();
